using Airbnb.Domain.Entities;
using Airbnb.Domain.Enums;

namespace Airbnb.Application.Common.Notifications.Events;

///<summary>
/// Represents a render notification event, derived from the base notification event.
///</summary>
public class RenderNotificationEvent : NotificationEvent
{
    ///<summary>
    /// Gets or sets the notification template associated with the event.
    ///</summary>
    public NotificationTemplate Template { get; set; } = default!;

    ///<summary>
    /// Gets or initializes the user sending the notification.
    ///</summary>
    public User SenderUser { get; init; } = default!;

    ///<summary>
    /// Gets or initializes the user receiving the notification.
    ///</summary>
    public User ReceiverUser { get; init; } = default!;

    ///<summary>
    /// Gets or sets the variables associated with the notification.
    ///</summary>
    public Dictionary<string, string> Variables { get; set; } = new();
}
