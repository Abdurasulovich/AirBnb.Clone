using System.Linq.Expressions;
using Airbnb.Domain.Entities;

namespace Airbnb.Persistence.Repositories.Interfaces;

///<summary>
/// Interface for managing email history-related data operations.
///</summary>
public interface IEmailHistoryRepository
{
    ///<summary>
    /// Gets a queryable collection of email histories based on the provided predicate and tracking options.
    ///</summary>
    ///<param name="predicate">The predicate to filter email histories.</param>
    ///<param name="asNoTracking">Indicates whether to enable tracking for the query.</param>
    ///<returns>A queryable collection of email histories.</returns>
    IQueryable<EmailHistory> Get(Expression<Func<EmailHistory, bool>>? predicate = default, bool asNoTracking = false);

    ///<summary>
    /// Asynchronously creates a new email history.
    ///</summary>
    ///<param name="emailHistory">The email history entity to create.</param>
    ///<param name="saveChanges">Indicates whether to save changes to the underlying data store.</param>
    ///<param name="cancellationToken">A token to monitor for cancellation requests.</param>
    ///<returns>An asynchronous operation that represents the creation of a new email history.</returns>
    ValueTask<EmailHistory> CreateAsync(EmailHistory emailHistory, bool saveChanges = true,
        CancellationToken cancellationToken = default);
}
