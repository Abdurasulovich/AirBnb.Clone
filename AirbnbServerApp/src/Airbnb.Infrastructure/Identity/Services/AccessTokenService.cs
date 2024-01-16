using Airbnb.Application.Common.Identity.Services.Interfaces;
using Airbnb.Identity.Domain.Entities;
using Airbnb.Persistence.Repositories.Interfaces;

namespace Airbnb.Infrastructure.Identity.Services;

///<summary>
/// Service for managing access tokens through an associated repository.
/// Initializes a new instance of the AccessTokenService class.
///</summary>
///<param name="accessTokenRepository">The repository for access token data.</param>
public class AccessTokenService(IAccessTokenRepository accessTokenRepository) : IAccessTokenService
{
    
    ///<summary>
    /// Creates an access token asynchronously.
    ///</summary>
    ///<param name="accessToken">The AccessToken object to be created.</param>
    ///<param name="saveChanges">Indicates whether to save changes to the repository. Default is true.</param>
    ///<param name="cancellationToken">A cancellation token to cancel the operation.</param>
    ///<returns>A ValueTask representing the asynchronous operation, returning the created AccessToken.</returns>
    public ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return accessTokenRepository.CreateAsync(accessToken, saveChanges, cancellationToken);
    }

    ///<summary>
    /// Retrieves an access token asynchronously based on the specified accessTokenId.
    ///</summary>
    ///<param name="accessTokenId">The unique identifier for the access token.</param>
    ///<param name="cancellationToken">A cancellation token to cancel the operation.</param>
    ///<returns>A ValueTask representing the asynchronous operation, returning nullable AccessToken.</returns>
    public ValueTask<AccessToken?> GetByIdAsync(Guid accessTokenId, CancellationToken cancellationToken = default)
    {
        return accessTokenRepository.GetByIdAsync(accessTokenId, cancellationToken);
    }

    ///<summary>
    /// Revokes an access token asynchronously based on the specified accessTokenId.
    ///</summary>
    ///<param name="accessTokenId">The unique identifier for the access token to be revoked.</param>
    ///<param name="cancellationToken">A cancellation token to cancel the operation.</param>
    public async ValueTask RevokeAsync(Guid accessTokenId, CancellationToken cancellationToken = default)
    {
        var accessToken = await GetByIdAsync(accessTokenId, cancellationToken);
        if (accessToken is null) throw new InvalidOperationException($"Access token with id {accessTokenId} not found");

        accessToken.IsRevoked = true;
        await accessTokenRepository.UpdateAsync(accessToken, cancellationToken);
    }
}