using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using Airbnb.Application.Common.Identity.Services.Interfaces;
using AirBnB.Domain.Common.Query;
using Airbnb.Domain.Entities;
using Airbnb.Domain.Enums;
using Airbnb.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Infrastructure.Identity.Services;

///<summary>
/// Service class for managing user-related operations, such as querying, creating, updating, and handling user images.
///</summary>
public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly string _folderPath = "Assets/User/";
    
    ///<summary>
    /// Gets a queryable collection of users based on the specified predicate and tracking options.
    ///</summary>
    ///<param name="predicate">The predicate used to filter users (optional).</param>
    ///<param name="asNoTracking">Flag indicating whether to use no-tracking for the query.</param>
    ///<returns>A queryable collection of users.</returns>
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false)
    {
        return userRepository.Get(predicate, asNoTracking);
    }

    ///<summary>
    /// Asynchronously gets a list of users based on the specified query specification and cancellation token.
    ///</summary>
    ///<param name="querySpecification">The query specification used to filter, order, and paginate the users.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the list of users.</returns>
    public ValueTask<IList<User>> GetAsync(QuerySpecification<User> querySpecification, CancellationToken cancellationToken = default)
    {
        return userRepository.GetAsync(querySpecification, cancellationToken);
    }

    ///<summary>
    /// Asynchronously gets a user by their identifier with optional tracking options.
    ///</summary>
    public ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return userRepository.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }

    
    ///<summary>
    /// Asynchronously gets the system user with optional tracking options.
    ///</summary>
    ///<param name="asNoTracking">Flag indicating whether to use no-tracking for the query.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the system user.</returns>

    public async ValueTask<User> GetSystemUserAsync(bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await Get(user => user.Role == RoleType.System, asNoTracking).FirstAsync(cancellationToken);
    }

    ///<summary>
    /// Asynchronously gets the unique identifier of a user by their email address.
    ///</summary>
    public async ValueTask<Guid?> GetIdByEmailAddressAsync(string emailAddress, CancellationToken cancellationToken = default)
    {
        var userId = await Get(user => user.EmailAddress == emailAddress, true).Select(user => user.Id)
            .FirstOrDefaultAsync(cancellationToken);
        return userId != Guid.Empty ? userId : default(Guid?);
    }

    ///<summary>
    /// Asynchronously creates a new user with optional saving and cancellation options.
    ///</summary>
    ///<param name="user">The user object to create.</param>
    ///<param name="saveChanges">Flag indicating whether to save changes to the data store (default is true).</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the created user.</returns>

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        // Create the user
        return await userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    ///<summary>
    /// Asynchronously updates an existing user with optional saving and cancellation options.
    ///</summary>
    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.UpdateAsync(user, saveChanges, cancellationToken);
    }

    ///<summary>
    /// Asynchronously uploads an image for the user with the specified identifier, using the provided form file,
    /// web root path, and cancellation token.
    ///</summary>
    ///<param name="id">The unique identifier of the user.</param>
    ///<param name="imagePath">The form file representing the image to upload.</param>
    ///<param name="webRootPath">The web root path where the image will be stored.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the path of the uploaded image.</returns>
    public async ValueTask<string> UploadImgAsync(Guid id, IFormFile imagePath, string webRootPath,
        CancellationToken cancellationToken = default)
    {
        
        // Find the user by ID
        var findFile = await GetByIdAsync(id, cancellationToken: cancellationToken) ??
                       throw new InvalidOperationException("LocationCategory with this id not found!");

        // Define the relative and absolute paths for storing the image
        var relativePath = _folderPath + id.ToString() + "." + imagePath.FileName.Split('.')[1];
        var filePath = Path.Combine(webRootPath, relativePath);
        
        // Delete the existing image file if it exists
        if(File.Exists(filePath)) File.Delete(filePath);
        
        // Save the new image file
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await imagePath.CopyToAsync(fileStream, cancellationToken);
        }

        // Update the user's image URL in the database
        findFile.ImageUrl = relativePath;
        await UpdateAsync(findFile, cancellationToken: cancellationToken);
        return relativePath;
    }
}