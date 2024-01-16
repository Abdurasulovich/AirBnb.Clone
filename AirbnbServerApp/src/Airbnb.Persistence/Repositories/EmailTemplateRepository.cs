using System.Linq.Expressions;
using Airbnb.Domain.Entities;
using Airbnb.Persistence.Caching.Brokers.Interfaces;
using Airbnb.Persistence.DataContexts;
using Airbnb.Persistence.Repositories.Interfaces;

namespace Airbnb.Persistence.Repositories;

///<summary>
/// Implementation of the IEmailTemplateRepository interface for managing email template-related data operations.
///</summary>
///<summary>
/// Initializes a new instance of the EmailTemplateRepository class with the specified database context and cache broker.
///</summary>
///<param name="dbContext">The database context for accessing the underlying storage.</param>
///<param name="cacheBroker">The cache broker for handling caching operations.</param>
public class EmailTemplateRepository(NotificationDbContext dbContext, ICacheBroker cacheBroker) 
    : EntityRepositoryBase<EmailTemplate, NotificationDbContext>(dbContext, cacheBroker), IEmailTemplateRepository
{
    ///<inheritdoc/>
    public new IQueryable<EmailTemplate> Get(Expression<Func<EmailTemplate, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    ///<inheritdoc/>
    public new ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(emailTemplate, saveChanges, cancellationToken);
    }
}
