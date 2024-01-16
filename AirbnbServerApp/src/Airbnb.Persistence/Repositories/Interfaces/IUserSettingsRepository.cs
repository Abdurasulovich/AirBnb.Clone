using Airbnb.Domain.Entities;
using Airbnb.Persistence.EntityConfigurations;

namespace Airbnb.Persistence.Repositories.Interfaces;
///<summary>
/// Interface for managing user settings-related data operations.
///</summary>
public interface IUserSettingsRepository
{
    ///<summary>
    /// Asynchronously retrieves user settings by their associated user's unique identifier.
    ///</summary>
    ///<param name="userId">The unique identifier of the user whose settings to retrieve.</param>
    ///<param name="asNoTracking">Indicates whether to enable tracking for the query.</param>
    ///<param name="cancellationToken">A token to monitor for cancellation requests.</param>
    ///<returns>An asynchronous operation that represents the retrieval of user settings by user identifier.</returns>
    ValueTask<UserSettings?> GetByIdAsync(Guid userId, bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously creates new user settings.
    ///</summary>
    ///<param name="userSettings">The user settings entity to create.</param>
    ///<param name="saveChanges">Indicates whether to save changes to the underlying data store.</param>
    ///<param name="cancellationToken">A token to monitor for cancellation requests.</param>
    ///<returns>An asynchronous operation that represents the creation of new user settings.</returns>
    ValueTask<UserSettings> CreateAsync(UserSettings userSettings, bool saveChanges = true,
        CancellationToken cancellationToken = default);
}
