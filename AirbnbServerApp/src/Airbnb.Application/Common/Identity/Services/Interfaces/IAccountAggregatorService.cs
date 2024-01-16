using Airbnb.Domain.Entities;

namespace Airbnb.Application.Common.Identity.Services.Interfaces;

///<summary>
/// Defines the interface for an account aggregator service.
///</summary>
public interface IAccountAggregatorService
{
    ///<summary>
    /// Asynchronously creates a user using the provided user details.
    ///</summary>
    ///<param name="user">The user object containing details for user creation.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and indicating whether the user creation was successful.</returns>
    ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default);
}
