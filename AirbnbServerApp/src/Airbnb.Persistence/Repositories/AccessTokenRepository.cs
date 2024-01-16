using System.Net;
using System.Runtime.InteropServices.JavaScript;
using Airbnb.Domain.Common.Caching;
using Airbnb.Identity.Domain.Entities;
using Airbnb.Persistence.Caching.Brokers.Interfaces;
using Airbnb.Persistence.Repositories.Interfaces;

namespace Airbnb.Persistence.Repositories;
///<summary>
/// Implementation of the IAccessTokenRepository interface for managing access token-related data operations.
///</summary>
public class AccessTokenRepository : IAccessTokenRepository
{
    private readonly ICacheBroker cacheBroker;

    ///<summary>
    /// Initializes a new instance of the AccessTokenRepository class with the specified cache broker.
    ///</summary>
    ///<param name="cacheBroker">The cache broker for handling caching operations.</param>
    public AccessTokenRepository(ICacheBroker cacheBroker)
    {
        this.cacheBroker = cacheBroker ?? throw new ArgumentNullException(nameof(cacheBroker));
    }

    ///<inheritdoc/>
    public async ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var cacheEntryOptions = new CacheEntryOptions(accessToken.ExpiryTime - DateTimeOffset.UtcNow, null);
        await cacheBroker.SetAsync(accessToken.Id.ToString(), accessToken, cacheEntryOptions, cancellationToken);

        return accessToken;
    }

    ///<inheritdoc/>
    public async ValueTask<AccessToken?> GetByIdAsync(Guid accessTokenId, CancellationToken cancellationToken = default)
    {
        return await cacheBroker.GetAsync<AccessToken>(accessTokenId.ToString(), cancellationToken);
    }

    ///<inheritdoc/>
    public async ValueTask<AccessToken> UpdateAsync(AccessToken accessToken, CancellationToken cancellationToken = default)
    {
        var cacheEntryOptions = new CacheEntryOptions(accessToken.ExpiryTime - DateTimeOffset.UtcNow, null);
        await cacheBroker.SetAsync(accessToken.Id.ToString(), accessToken, cacheEntryOptions, cancellationToken);

        return accessToken;
    }
}
