using Airbnb.Domain.Common.Entities.Interfaces;
using Airbnb.Domain.Enums;

namespace Airbnb.Domain.Entities;

/// <summary>
/// Base class for representing notification histories with common properties.
/// Implements the IEntity interface.
/// </summary>
public abstract class NotificationHistory : IEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the notification history.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets the unique identifier for the associated notification template.
    /// </summary>
    public Guid TemplateId { get; set; }
    
    /// <summary>
    /// Gets or sets the unique identifier for the sender user.
    /// </summary>
    public Guid SenderUserId { get; set; }
    
    /// <summary>
    /// Gets or sets the unique identifier for the receiver user.
    /// </summary>
    public Guid ReceiverUserId { get; set; }
    
    /// <summary>
    /// Gets or sets the type of the notification.
    /// </summary>
    public NotificationType Type { get; set; }

    /// <summary>
    /// Gets or sets the content of the notification history.
    /// Initialized to a default non-null value.
    /// </summary>
    public string Content { get; set; } = default!;
    
    /// <summary>
    /// Gets or sets a flag indicating whether the notification was sent successfully.
    /// </summary>
    public bool IsSuccessful { get; set; }
    
    /// <summary>
    /// Gets or sets the optional error message associated with the notification.
    /// Nullable to indicate the absence of an error message.
    /// </summary>
    public string? ErrorMessage { get; set; }
    
    /// <summary>
    /// Gets or sets the associated notification template.
    /// </summary>
    public NotificationTemplate Template { get; set; }
}
