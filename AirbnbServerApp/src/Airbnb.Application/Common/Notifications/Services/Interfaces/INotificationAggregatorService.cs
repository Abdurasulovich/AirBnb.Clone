using Airbnb.Application.Common.Notifications.Events;
using Airbnb.Domain.Common.Exceptions;
using Airbnb.Domain.Entities;

namespace Airbnb.Application.Common.Notifications.Services.Interfaces;

///<summary>
/// Defines the interface for a notification aggregator service.
///</summary>
public interface INotificationAggregatorService
{
    ///<summary>
    /// Asynchronously sends a notification based on the provided process notification event.
    ///</summary>
    ///<param name="processNotificationEvent">The process notification event containing information about the notification.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the result of the send operation.</returns>
    ValueTask<FuncResult<bool>> SendAsync(ProcessNotificationEvent processNotificationEvent,
        CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously retrieves notification templates based on the provided filter.
    ///</summary>
    ///<param name="notificationTemplate">The filter criteria for retrieving notification templates.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the list of matching notification templates.</returns>
    ValueTask<IList<NotificationTemplate>> GetTemplatesByFilterAsync(
        NotificationTemplate notificationTemplate, 
        CancellationToken cancellationToken = default);
}
