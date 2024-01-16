using System.Linq.Expressions;
using Airbnb.Domain.Common.Exceptions;
using Airbnb.Domain.Entities;

namespace Airbnb.Persistence.Repositories.Interfaces;

///<summary>
/// Interface for managing email template-related data operations.
///</summary>
public interface IEmailTemplateRepository
{
    ///<summary>
    /// Gets a queryable collection of email templates based on the provided predicate and tracking options.
    ///</summary>
    ///<param name="predicate">The predicate to filter email templates.</param>
    ///<param name="asNoTracking">Indicates whether to enable tracking for the query.</param>
    ///<returns>A queryable collection of email templates.</returns>
    IQueryable<EmailTemplate> Get(Expression<Func<EmailTemplate, bool>>? predicate = default,
        bool asNoTracking = false);

    ///<summary>
    /// Asynchronously creates a new email template.
    ///</summary>
    ///<param name="emailTemplate">The email template entity to create.</param>
    ///<param name="saveChanges">Indicates whether to save changes to the underlying data store.</param>
    ///<param name="cancellationToken">A token to monitor for cancellation requests.</param>
    ///<returns>An asynchronous operation that represents the creation of a new email template.</returns>
    ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate, bool saveChanges = true,
        CancellationToken cancellationToken = default);
}
