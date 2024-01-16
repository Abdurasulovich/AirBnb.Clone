using Airbnb.Domain.Entities;

namespace Airbnb.Application.Common.Identity.Services.Interfaces;

///<summary>
/// Defines the interface for user settings-related operations.
///</summary>
public interface IUserSettingsService
{
    ///<summary>
    /// Asynchronously gets user settings by their identifier with optional tracking options.
    ///</summary>
    ///<param name="userSettingsId">The unique identifier of the user settings.</param>
    ///<param name="asNoTracking">Flag indicating whether to use no-tracking for the query.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the user settings or null if not found.</returns>
    ValueTask<UserSettings?> GetByIdAsync(Guid userSettingsId, bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously creates new user settings with optional saving and cancellation options.
    ///</summary>
    ///<param name="userSettings">The user settings object to create.</param>
    ///<param name="saveChanges">Flag indicating whether to save changes to the data store (default is true).</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the created user settings.</returns>
    ValueTask<UserSettings> CreateAsync(UserSettings userSettings, bool saveChanges = true,
        CancellationToken cancellationToken = default);
}
