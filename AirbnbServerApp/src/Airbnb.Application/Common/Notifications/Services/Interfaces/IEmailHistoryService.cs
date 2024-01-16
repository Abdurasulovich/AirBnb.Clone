using System.Runtime.InteropServices;
using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;

namespace Airbnb.Application.Common.Notifications.Services.Interfaces;

///<summary>
/// Defines the interface for an email history service.
///</summary>
public interface IEmailHistoryService
{
    ///<summary>
    /// Asynchronously retrieves email histories based on the provided filter criteria.
    ///</summary>
    ///<param name="paginationOptions">The filter criteria for retrieving email histories.</param>
    ///<param name="asNoTracking">Flag indicating whether to disable tracking of entities (default is false).</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the list of matching email histories.</returns>
    ValueTask<IList<EmailHistory>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously creates an email history.
    ///</summary>
    ///<param name="emailHistory">The email history object to create.</param>
    ///<param name="saveChanges">Flag indicating whether to save changes to the data store (default is true).</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the created email history.</returns>
    ValueTask<EmailHistory> CreateAsync(
        EmailHistory emailHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}
