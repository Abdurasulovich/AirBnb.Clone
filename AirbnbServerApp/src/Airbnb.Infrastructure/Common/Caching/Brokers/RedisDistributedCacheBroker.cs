using Airbnb.Domain.Common.Caching;
using Airbnb.Infrastructure.Settings;
using Airbnb.Persistence.Caching.Brokers.Interfaces;
using Force.DeepCloner;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;
using Airbnb.Application.Common.Serializer;

namespace Airbnb.Infrastructure.Common.Caching.Brokers;

public class RedisDistributedCacheBroker(IOptions<CacheSettings> cacheSettins, 
    IDistributedCache distributedCache,
    IJsonSerializationSettingsProvider jsonSerializationSettingsProvider) : ICacheBroker
{
    private readonly DistributedCacheEntryOptions _entryOption = new();
    private readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
    {
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    };

    public async ValueTask SetAsync<T>(string key, T value, CacheEntryOptions? cacheEntryOptions = default,
        CancellationToken cancellationToken = default)
    {
        await distributedCache.SetStringAsync(
            key,
            JsonConvert.SerializeObject(value, jsonSerializationSettingsProvider.Get()),
            cancellationToken
        );
    }

    public ValueTask DeleteAsync(string key)
    {
        distributedCache.Remove(key);
        return ValueTask.CompletedTask;
    }

    public async ValueTask<T> GetAsync<T>(string key)
    {
        var value = await distributedCache.GetAsync(key);
        return value is not null ? JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(value), JsonSettings) : default;
    }

    public async ValueTask<T> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, CacheEntryOptions? cacheEntryOptions)
    {
        var cacheValue = await distributedCache.GetStringAsync(key);
        if (cacheValue is not null) return JsonConvert.DeserializeObject<T>(cacheValue, JsonSettings);

        var value = await valueFactory();
        await SetAsync(key, await valueFactory(), cacheEntryOptions);

        return value;
    }

    public async ValueTask SetAsync<T>(string key, T value, CacheEntryOptions? cacheEntryOptions = null)
    {
        await distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(value, JsonSettings),
            GetCacheEntryOptions(cacheEntryOptions));
    }

    public ValueTask<bool> TryGetAsync<T>(string key, out T? value)
    {
        var foundEntry = distributedCache.GetString(key);

        if(foundEntry is not null)
        {
            value = JsonConvert.DeserializeObject<T>(foundEntry, JsonSettings);
            return ValueTask.FromResult(true);
        }

        value = default;
        return ValueTask.FromResult(false);
    }

    public DistributedCacheEntryOptions GetCacheEntryOptions(CacheEntryOptions? cacheEntryOptions)
    {
        if (_entryOption == default || (!_entryOption.AbsoluteExpirationRelativeToNow.HasValue && !_entryOption.SlidingExpiration.HasValue))
            return _entryOption;

        var currentEntryOptions = _entryOption.DeepClone();

        currentEntryOptions.AbsoluteExpirationRelativeToNow = _entryOption.AbsoluteExpirationRelativeToNow;
        currentEntryOptions.SlidingExpiration = _entryOption.SlidingExpiration;

        return currentEntryOptions;
    }
}