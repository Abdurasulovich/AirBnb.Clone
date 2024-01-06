using Airbnb.Domain.Common.Caching;
using Airbnb.Infrastructure.Settings;
using Airbnb.Persistence.Caching.Brokers.Interfaces;
using Force.DeepCloner;
using LazyCache;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Infrastructure.Common.Caching.Brokers;

public class LazyMemoryCacheBroker(IAppCache appCache, IOptions<CacheSettings> cacheSettings) : ICacheBroker
{
    private readonly MemoryCacheEntryOptions _entryOptions = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheSettings.Value.AbsoluteExpirationInSeconds),
        SlidingExpiration = TimeSpan.FromSeconds(cacheSettings.Value.SlidingExpirationInSeconds)
    };

    public ValueTask DeleteAsync(string key)
    {
        appCache.Remove(key);
        return ValueTask.CompletedTask;
    }

    public async ValueTask<T> GetAsync<T>(string key)
        => await appCache.GetAsync<T>(key);

    public async ValueTask<T> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, CacheEntryOptions? cacheEntryOptions)
        => await appCache.GetOrAddAsync(key, valueFactory, GetCacheEntryOptions(cacheEntryOptions));

    public ValueTask SetAsync<T>(string key, T value, CacheEntryOptions? cacheEntryOptions = null)
    {
        appCache.Add(key, value, GetCacheEntryOptions(cacheEntryOptions));
        return ValueTask.CompletedTask;
    }

    public ValueTask<bool> TryGetAsync<T>(string key, out T? value)
        => new ValueTask<bool>(appCache.TryGetValue(key, out value));


    public MemoryCacheEntryOptions GetCacheEntryOptions(CacheEntryOptions? cacheEntryOptions)
    {
        if (cacheEntryOptions == default || (!cacheEntryOptions.AbsoluteExpirationRelativeNow.HasValue && !cacheEntryOptions.SlidingExpiration.HasValue))
            return _entryOptions;

        var currentEntryOptions = _entryOptions.DeepClone();

        currentEntryOptions.AbsoluteExpirationRelativeToNow = cacheEntryOptions.AbsoluteExpirationRelativeNow;
        currentEntryOptions.SlidingExpiration = cacheEntryOptions.SlidingExpiration;

        return currentEntryOptions;
    }
}