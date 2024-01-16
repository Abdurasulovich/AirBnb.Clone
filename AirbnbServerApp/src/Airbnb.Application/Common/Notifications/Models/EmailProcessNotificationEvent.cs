using Airbnb.Application.Common.Notifications.Events;
using Airbnb.Domain.Enums;

namespace Airbnb.Application.Common.Notifications.Models;

///<summary>
/// Represents an email process notification event, derived from the base process notification event.
///</summary>
public class EmailProcessNotificationEvent : ProcessNotificationEvent
{
    ///<summary>
    /// Initializes a new instance of the <see cref="EmailProcessNotificationEvent"/> class.
    /// Sets the event type to email.
    ///</summary>
    public EmailProcessNotificationEvent()
    {
        Type = NotificationType.Email;
    }
}
