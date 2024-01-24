using System.Linq.Expressions;
using Airbnb.Domain.Entities;

namespace Airbnb.Persistence.Repositories.Interfaces;

///<summary>
/// Interface for managing user info verification codes-related data operations.
///</summary>
public interface IUserInfoVerificationCodeRepository
{
    ///<summary>
    /// Gets a queryable collection of user info verification codes based on the provided predicate and tracking options.
    ///</summary>
    ///<param name="predicate">The predicate to filter user info verification codes.</param>
    ///<param name="asNoTracking">Indicates whether to enable tracking for the query.</param>
    ///<returns>A queryable collection of user info verification codes.</returns>
    IQueryable<UserInfoVerificationCode> Get(Expression<Func<UserInfoVerificationCode, bool>>? predicate = default,
        bool asNoTracking = false);

    ///<summary>
    /// Asynchronously retrieves a user info verification code by its unique identifier.
    ///</summary>
    ///<param name="codeId">The unique identifier of the user info verification code to retrieve.</param>
    ///<param name="asNoTracking">Indicates whether to enable tracking for the query.</param>
    ///<param name="cancellationToken">A token to monitor for cancellation requests.</param>
    ///<returns>An asynchronous operation that represents the retrieval of a user info verification code by its unique identifier.</returns>
    ValueTask<UserInfoVerificationCode?> GetByIdAsync(Guid codeId, bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously creates a new user info verification code.
    ///</summary>
    ///<param name="userInfoVerificationCode">The user info verification code entity to create.</param>
    ///<param name="saveChanges">Indicates whether to save changes to the underlying data store.</param>
    ///<param name="cancellationToken">A token to monitor for cancellation requests.</param>
    ///<returns>An asynchronous operation that represents the creation of a new user info verification code.</returns>
    ValueTask<UserInfoVerificationCode> CreateAsync(
        UserInfoVerificationCode userInfoVerificationCode,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );

    ValueTask DeactivateAsync(Guid codeId, bool saveChanges = true, CancellationToken cancellationToken = default);
}
