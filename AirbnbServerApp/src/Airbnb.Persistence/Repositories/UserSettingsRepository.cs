using Airbnb.Domain.Entities;
using Airbnb.Persistence.Caching.Brokers.Interfaces;
using Airbnb.Persistence.DataContexts;
using Airbnb.Persistence.Repositories.Interfaces;

namespace Airbnb.Persistence.Repositories;

///<summary>
/// Implementation of the IUserSettingsRepository interface for managing user information verification code-related data operations.
///</summary>
///<summary>
/// Initializes a new instance of the UserSettingsRepository class with the specified database context and cache broker.
///</summary>
///<param name="dbContext">The database context for accessing the underlying storage.</param>
///<param name="cacheBroker">The cache broker for handling caching operations.</param>

public class UserSettingsRepository(IdentityDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<UserSettings, IdentityDbContext>(dbContext, cacheBroker), IUserSettingsRepository
{
    ///<inheritdoc/>
    public new ValueTask<UserSettings?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }

    ///<inheritdoc/>
    public new ValueTask<UserSettings> CreateAsync(UserSettings userSettings, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(userSettings, saveChanges, cancellationToken);
    }
}