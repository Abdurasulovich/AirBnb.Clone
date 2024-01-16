using Airbnb.Domain.Entities;

namespace Airbnb.Application.Common.Notifications.Models;

///<summary>
/// Represents a notification message, including the body, associated template, variables, success status, and error message.
///</summary>
public class NotificationMessage
{
    ///<summary>
    /// Gets or sets the body of the notification message.
    ///</summary>
    public string Body { get; set; } = default!;

    ///<summary>
    /// Gets or sets the template associated with the notification message.
    ///</summary>
    public NotificationTemplate Template { get; set; } = default!;

    ///<summary>
    /// Gets or sets the variables used in the notification message.
    ///</summary>
    public Dictionary<string, string> Variables { get; set; } = default!;
    
    ///<summary>
    /// Gets or sets a boolean indicating whether the notification message was sent successfully.
    ///</summary>
    public bool IsSuccessful { get; set; }
    
    ///<summary>
    /// Gets or sets an optional error message if the notification message sending was unsuccessful.
    ///</summary>
    public string? ErrorMessage { get; set; }
}
