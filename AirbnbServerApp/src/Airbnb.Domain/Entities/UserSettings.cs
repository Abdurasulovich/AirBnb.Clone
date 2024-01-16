using Airbnb.Domain.Common.Entities.Interfaces;
using Airbnb.Domain.Enums;

namespace Airbnb.Domain.Entities;

/// <summary>
/// Represents user-specific settings including preferred notification type.
/// Implements the IEntity interface.
/// </summary>
public class UserSettings : IEntity
{
    /// <summary>
    /// Gets or sets the preferred notification type for the user.
    /// Nullable to indicate no preference.
    /// </summary>
    public NotificationType? PreferredNotificationType { get; set; }
    
    /// <summary>
    /// Gets or sets the unique identifier for the user settings.
    /// </summary>
    public Guid Id { get; set; }
}
