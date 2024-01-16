using Airbnb.Application.Common.Identity.Services.Interfaces;
using Airbnb.Domain.Entities;
using Airbnb.Persistence.Repositories.Interfaces;

namespace Airbnb.Infrastructure.Identity.Services;

///<summary>
/// Service for managing user settings through an associated repository.
/// Initializes a new instance of the UserSettingsService class.
///</summary>
///<param name="userSettingsRepository">The repository for user settings data.</param>
public class UserSettingsService(IUserSettingsRepository userSettingsRepository) : IUserSettingsService
{
    
    ///<summary>
    /// Retrieves user settings asynchronously based on the specified userSettingsId.
    ///</summary>
    ///<param name="userSettingsId">The unique identifier for the user settings.</param>
    ///<param name="asNoTracking">Indicates whether to use entity tracking. Default is false.</param>
    ///<param name="cancellationToken">A cancellation token to cancel the operation.</param>
    ///<returns>A ValueTask representing the asynchronous operation, returning nullable UserSettings.</returns>
    public ValueTask<UserSettings?> GetByIdAsync(Guid userSettingsId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return userSettingsRepository.GetByIdAsync(userSettingsId, asNoTracking, cancellationToken);
    }

    ///<summary>
    /// Creates user settings asynchronously using the provided UserSettings object.
    ///</summary>
    ///<param name="userSettings">The UserSettings object to be created.</param>
    ///<param name="saveChanges">Indicates whether to save changes to the repository. Default is true.</param>
    ///<param name="cancellationToken">A cancellation token to cancel the operation.</param>
    ///<returns>A ValueTask representing the asynchronous operation, returning the created UserSettings.</returns>
    public ValueTask<UserSettings> CreateAsync(UserSettings userSettings, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        return userSettingsRepository.CreateAsync(userSettings, saveChanges, cancellationToken);
    }
}