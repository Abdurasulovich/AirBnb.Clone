using Type = Airbnb.Domain.Enums.NotificationType;

namespace Airbnb.Domain.Entities;

///<summary>
/// Represents an email-specific notification template.
///</summary>
public class EmailTemplate : NotificationTemplate
{
    ///<summary>
    /// Constructor initializing the notification type to Email.
    ///</summary>
    public EmailTemplate()
    {
        Type = Type.Email;
    }

    ///<summary>
    /// Gets or sets the subject of the email template.
    ///</summary>
    public string Subject { get; set; } = default!;
}