using Airbnb.Application.Common.Notifications.Models;

namespace Airbnb.Application.Common.Notifications.Events;

///<summary>
/// Represents a sender notification event, derived from the base notification event.
///</summary>
public class SenderNotificationEvent : NotificationEvent
{
    ///<summary>
    /// Gets or sets the notification message associated with the event.
    ///</summary>
    public NotificationMessage Message { get; set; } = default!;
}
