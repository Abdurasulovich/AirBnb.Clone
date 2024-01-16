using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using Airbnb.Domain.Enums;

namespace Airbnb.Application.Common.Notifications.Services.Interfaces;

///<summary>
/// Defines the interface for an email template service.
///</summary>
public interface IEmailTemplateService
{
    ///<summary>
    /// Asynchronously retrieves email templates based on the provided filter criteria.
    ///</summary>
    ///<param name="filterPagination">The filter criteria for retrieving email templates.</param>
    ///<param name="asNoTracking">Flag indicating whether to disable tracking of entities (default is false).</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the list of matching email templates.</returns>
    ValueTask<IList<EmailTemplate>> GetByFilterAsync(
        FilterPagination filterPagination,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously retrieves an email template by its template type.
    ///</summary>
    ///<param name="templateType">The template type to filter by.</param>
    ///<param name="asNoTracking">Flag indicating whether to disable tracking of entities (default is false).</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the matching email template or null if not found.</returns>
    ValueTask<EmailTemplate?> GetByTypeAsync(
        NotificationTemplateType templateType,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously creates an email template.
    ///</summary>
    ///<param name="emailTemplate">The email template object to create.</param>
    ///<param name="saveChanges">Flag indicating whether to save changes to the data store (default is true).</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the created email template.</returns>
    ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}
