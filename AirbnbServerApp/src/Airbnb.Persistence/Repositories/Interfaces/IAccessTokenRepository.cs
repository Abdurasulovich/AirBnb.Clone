using Airbnb.Identity.Domain.Entities;

namespace Airbnb.Persistence.Repositories.Interfaces;

///<summary>
/// Interface for managing access token-related data operations.
///</summary>
public interface IAccessTokenRepository
{
    ///<summary>
    /// Asynchronously creates a new access token.
    ///</summary>
    ///<param name="accessToken">The access token entity to create.</param>
    ///<param name="saveChanges">Indicates whether to save changes to the underlying data store.</param>
    ///<param name="cancellationToken">A token to monitor for cancellation requests.</param>
    ///<returns>An asynchronous operation that represents the creation of a new access token.</returns>
    ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously retrieves an access token by its unique identifier.
    ///</summary>
    ///<param name="accessTokenId">The unique identifier of the access token to retrieve.</param>
    ///<param name="cancellationToken">A token to monitor for cancellation requests.</param>
    ///<returns>An asynchronous operation that represents the retrieval of an access token by its unique identifier.</returns>
    ValueTask<AccessToken?> GetByIdAsync(Guid accessTokenId, CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously updates an access token.
    ///</summary>
    ///<param name="accessToken">The access token entity to update.</param>
    ///<param name="cancellationToken">A token to monitor for cancellation requests.</param>
    ///<returns>An asynchronous operation that represents the update of an access token.</returns>
    ValueTask<AccessToken> UpdateAsync(AccessToken accessToken, CancellationToken cancellationToken = default);
}
