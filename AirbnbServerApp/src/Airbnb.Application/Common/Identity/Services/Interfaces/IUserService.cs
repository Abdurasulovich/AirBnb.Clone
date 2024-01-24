using System.Linq.Expressions;
using AirBnB.Domain.Common.Query;
using Airbnb.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Airbnb.Application.Common.Identity.Services.Interfaces;
///<summary>
/// Defines the interface for user-related operations.
///</summary>
public interface IUserService
{
    ///<summary>
    /// Gets a queryable collection of users based on the specified predicate and tracking options.
    ///</summary>
    ///<param name="predicate">The predicate used to filter users (optional).</param>
    ///<param name="asNoTracking">Flag indicating whether to use no-tracking for the query.</param>
    ///<returns>A queryable collection of users.</returns>
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false);

    ///<summary>
    /// Asynchronously gets a list of users based on the specified query specification and cancellation token.
    ///</summary>
    ///<param name="querySpecification">The query specification used to filter, order, and paginate the users.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the list of users.</returns>
    ValueTask<IList<User>> GetAsync(QuerySpecification<User> querySpecification,
        CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously gets a user by their identifier with optional tracking options.
    ///</summary>
    ///<param name="userId">The unique identifier of the user.</param>
    ///<param name="asNoTracking">Flag indicating whether to use no-tracking for the query.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the user or null if not found.</returns>
    ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously gets the system user with optional tracking options.
    ///</summary>
    ///<param name="asNoTracking">Flag indicating whether to use no-tracking for the query.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the system user.</returns>
    ValueTask<User> GetSystemUserAsync(bool asNoTracking = false, CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously gets the unique identifier of a user by their email address.
    ///</summary>
    ///<param name="emailAddress">The email address of the user.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the unique identifier of the user or null if not found.</returns>
    ValueTask<Guid?> GetIdByEmailAddressAsync(string emailAddress, CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously creates a new user with optional saving and cancellation options.
    ///</summary>
    ///<param name="user">The user object to create.</param>
    ///<param name="saveChanges">Flag indicating whether to save changes to the data store (default is true).</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the created user.</returns>
    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously updates an existing user with optional saving and cancellation options.
    ///</summary>
    ///<param name="user">The user object to update.</param>
    ///<param name="saveChanges">Flag indicating whether to save changes to the data store (default is true).</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the updated user.</returns>
    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
    
    ///<summary>
    /// Asynchronously uploads an image for the user with the specified identifier, using the provided form file,
    /// web root path, and cancellation token.
    ///</summary>
    ///<param name="id">The unique identifier of the user.</param>
    ///<param name="imagePath">The form file representing the image to upload.</param>
    ///<param name="webRootPath">The web root path where the image will be stored.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the path of the uploaded image.</returns>
    ValueTask<string> UploadImgAsync(Guid id, IFormFile imagePath, string webRootPath, CancellationToken cancellationToken = default);
}
