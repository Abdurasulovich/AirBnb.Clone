using Airbnb.Domain.Common.Caching;

namespace Airbnb.Persistence.Caching.Brokers.Interfaces;

public interface ICacheBroker
{
    ValueTask<T> GetAsync<T>(string key);

    ValueTask<bool> TryGetAsync<T>(string key, out T? value);

    ValueTask<T> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, CacheEntryOptions? cacheEntryOptions);

    ValueTask SetAsync<T>(string key, T value, CacheEntryOptions? cacheEntryOptions = default);

    ValueTask DeleteAsync(string key);
}
