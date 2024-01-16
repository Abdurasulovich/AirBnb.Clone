using System.Linq.Expressions;
using Airbnb.Domain.Entities;
using Airbnb.Persistence.Caching.Brokers.Interfaces;
using Airbnb.Persistence.DataContexts;
using Airbnb.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Persistence.Repositories;
///<summary>
/// Implementation of the IEmailHistoryRepository interface for managing email history-related data operations.
///</summary>
public class EmailHistoryRepository : EntityRepositoryBase<EmailHistory, NotificationDbContext>, IEmailHistoryRepository
{
    ///<summary>
    /// Initializes a new instance of the EmailHistoryRepository class with the specified database context and cache broker.
    ///</summary>
    ///<param name="dbContext">The database context for accessing the underlying storage.</param>
    ///<param name="cacheBroker">The cache broker for handling caching operations.</param>
    public EmailHistoryRepository(NotificationDbContext dbContext, ICacheBroker cacheBroker)
        : base(dbContext, cacheBroker)
    {
    }

    ///<inheritdoc/>
    public new IQueryable<EmailHistory> Get(Expression<Func<EmailHistory, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    ///<inheritdoc/>
    public new async ValueTask<EmailHistory> CreateAsync(EmailHistory emailHistory, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        if (emailHistory.EmailTemplate is not null)
            DbContext.Entry(emailHistory.EmailTemplate).State = EntityState.Unchanged;

        var createdHistory = await base.CreateAsync(emailHistory, saveChanges, cancellationToken);

        if (emailHistory.EmailTemplate is not null)
            DbContext.Entry(emailHistory.EmailTemplate).State = EntityState.Detached;

        return createdHistory;
    }
}
