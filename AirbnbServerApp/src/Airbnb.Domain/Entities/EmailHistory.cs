using System.ComponentModel.DataAnnotations.Schema;
using Airbnb.Domain.Entities;
using Airbnb.Domain.Enums;

namespace Airbnb.Domain.Entities;

///<summary>
/// Represents a history of email notifications.
///</summary>
public class EmailHistory : NotificationHistory
{
    ///<summary>
    /// Constructor initializing the notification type to Email.
    ///</summary>
    public EmailHistory()
    {
        Type = NotificationType.Email;
    }

    ///<summary>
    /// Gets or sets the sender's email address for the email history.
    ///</summary>
    public string SenderEmailAddress { get; set; } = default!;

    ///<summary>
    /// Gets or sets the receiver's email address for the email history.
    ///</summary>
    public string ReceiverEmailAddress { get; set; } = default!;

    ///<summary>
    /// Gets or sets the subject of the email history.
    ///</summary>
    public string Subject { get; set; } = default!;

    ///<summary>
    /// Gets or sets the associated email template (not mapped to the database).
    ///</summary>
    [NotMapped]
    public EmailTemplate EmailTemplate
    {
        get => Template is not null ? Template as EmailTemplate : null;
        set => Template = value;
    }
}
