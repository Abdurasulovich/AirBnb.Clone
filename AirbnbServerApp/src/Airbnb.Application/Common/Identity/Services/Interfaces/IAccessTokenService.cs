using Airbnb.Identity.Domain.Entities;

namespace Airbnb.Application.Common.Identity.Services.Interfaces;

///<summary>
/// Defines the interface for access token-related operations.
///</summary>
public interface IAccessTokenService
{
    ///<summary>
    /// Asynchronously creates an access token with optional saving and cancellation options.
    ///</summary>
    ///<param name="accessToken">The access token object to create.</param>
    ///<param name="saveChanges">Flag indicating whether to save changes to the data store (default is true).</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the created access token.</returns>
    ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously gets an access token by its identifier.
    ///</summary>
    ///<param name="accessTokenId">The unique identifier of the access token.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the access token or null if not found.</returns>
    ValueTask<AccessToken?> GetByIdAsync(Guid accessTokenId, CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously revokes an access token by its identifier.
    ///</summary>
    ///<param name="accessTokenId">The unique identifier of the access token to revoke.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation.</returns>
    ValueTask RevokeAsync(Guid accessTokenId, CancellationToken cancellationToken = default);
}
