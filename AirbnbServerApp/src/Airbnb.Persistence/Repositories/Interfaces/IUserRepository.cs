using System.Linq.Expressions;
using AirBnB.Domain.Common.Query;
using Airbnb.Domain.Entities;

namespace Airbnb.Persistence.Repositories.Interfaces;

///<summary>
/// Interface for managing user-related data operations.
///</summary>
public interface IUserRepository
{
    ///<summary>
    /// Gets a queryable collection of users based on the provided predicate and tracking options.
    ///</summary>
    ///<param name="predicate">The predicate to filter users.</param>
    ///<param name="asNoTracking">Indicates whether to enable tracking for the query.</param>
    ///<returns>A queryable collection of users.</returns>
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false);

    ///<summary>
    /// Asynchronously retrieves a list of users based on the provided query specification.
    ///</summary>
    ///<param name="querySpecification">The query specification to define filtering, ordering, and pagination options.</param>
    ///<param name="cancellationToken">A token to monitor for cancellation requests.</param>
    ///<returns>An asynchronous operation that represents the retrieval of a list of users.</returns>
    ValueTask<IList<User>> GetAsync(QuerySpecification<User> querySpecification,
        CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously retrieves a user by their unique identifier.
    ///</summary>
    ///<param name="userId">The unique identifier of the user to retrieve.</param>
    ///<param name="asNoTracking">Indicates whether to enable tracking for the query.</param>
    ///<param name="cancellationToken">A token to monitor for cancellation requests.</param>
    ///<returns>An asynchronous operation that represents the retrieval of a user by their unique identifier.</returns>
    ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously creates a new user.
    ///</summary>
    ///<param name="user">The user entity to create.</param>
    ///<param name="saveChanges">Indicates whether to save changes to the underlying data store.</param>
    ///<param name="cancellationToken">A token to monitor for cancellation requests.</param>
    ///<returns>An asynchronous operation that represents the creation of a new user.</returns>
    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously updates an existing user.
    ///</summary>
    ///<param name="user">The user entity to update.</param>
    ///<param name="saveChanges">Indicates whether to save changes to the underlying data store.</param>
    ///<param name="cancellationToken">A token to monitor for cancellation requests.</param>
    ///<returns>An asynchronous operation that represents the update of an existing user.</returns>
    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
}
