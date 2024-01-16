using Airbnb.Domain.Enums;

namespace Airbnb.Application.Common.Notifications.Events;

///<summary>
/// Represents a process notification event, derived from the base notification event.
///</summary>
public class ProcessNotificationEvent : NotificationEvent
{
    ///<summary>
    /// Gets or initializes the template type of the notification.
    ///</summary>
    public NotificationTemplateType TemplateType { get; init; }

    ///<summary>
    /// Gets or sets the notification type.
    ///</summary>
    public NotificationType? Type { get; set; }
    
    ///<summary>
    /// Gets or sets the variables associated with the notification.
    ///</summary>
    public Dictionary<string, string>? Variables { get; set; }
}
