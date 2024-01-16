using Airbnb.Domain.Entities;
using Newtonsoft.Json;

namespace Airbnb.Application.Common.Notifications.Models;

///<summary>
/// Represents an email message, derived from the base notification message.
///</summary>
public class EmailMessage : NotificationMessage
{
    ///<summary>
    /// Gets or sets the email address of the message receiver.
    ///</summary>
    public string ReceiverEmailAddress { get; set; } = default!;

    ///<summary>
    /// Gets or sets the email address of the message sender.
    ///</summary>
    public string SenderEmailAddress { get; set; } = default!;

    ///<summary>
    /// Gets or sets the subject of the email message.
    ///</summary>
    public string Subject { get; set; } = default!;

    ///<summary>
    /// Gets or sets the associated email template, using JSON ignore to prevent serialization.
    ///</summary>
    [JsonIgnore]
    public EmailTemplate EmailTemplate
    {
        get => (EmailTemplate)Template;
        set => Template = value;
    }
}
