using Airbnb.Domain.Common.Entities.Interfaces;
using Airbnb.Domain.Enums;

namespace Airbnb.Domain.Entities;

/// <summary>
/// Base class for representing notification templates with common properties.
/// Implements the IEntity interface.
/// </summary>
public abstract class NotificationTemplate : IEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the notification template.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets the type of the notification.
    /// </summary>
    public NotificationType Type { get; set; }
    
    /// <summary>
    /// Gets or sets the template type of the notification.
    /// </summary>
    public NotificationTemplateType TemplateType { get; set; }

    /// <summary>
    /// Gets or sets the content of the notification template.
    /// Initialized to a default non-null value.
    /// </summary>
    public string Content { get; set; } = default!;

    /// <summary>
    /// Gets or sets the list of notification histories associated with the template.
    /// Initialized to an empty list.
    /// </summary>
    public IList<NotificationHistory> Histories { get; set; } = new List<NotificationHistory>();
}
