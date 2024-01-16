using Airbnb.Domain.Common.Events;

namespace Airbnb.Application.Common.Notifications.Events;

///<summary>
/// Represents a generic notification event, derived from the base event.
///</summary>
public class NotificationEvent : Event
{
    ///<summary>
    /// Gets or initializes the unique identifier of the user sending the notification.
    ///</summary>
    public Guid SenderUserId { get; init; }
    
    ///<summary>
    /// Gets or initializes the unique identifier of the user receiving the notification.
    ///</summary>
    public Guid ReceiverUserId { get; init; }
}
