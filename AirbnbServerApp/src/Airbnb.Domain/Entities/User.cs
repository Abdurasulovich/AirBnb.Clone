using Airbnb.Domain.Common.Entities;
using Airbnb.Domain.Enums;

namespace Airbnb.Domain.Entities;

/// <summary>
/// Represents a user entity with common user-related properties.
/// Inherits from the Entity class.
/// </summary>
public class User : Entity
{
    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public string LastName { get; set; } = default!;
    
    /// <summary>
    /// Gets or sets the birth date of the user.
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public string EmailAddress { get; set; } = default!;

    /// <summary>
    /// Gets or sets the password hash associated with the user's password.
    /// </summary>
    public string PasswordHash { get; set; } = default!;
    
    /// <summary>
    /// Gets or sets a flag indicating whether the user's email address is verified.
    /// </summary>
    public bool IsEmailAddressVerified { get; set; }

    /// <summary>
    /// Gets or sets user profile image url 
    /// </summary>
    public string? ImageUrl { get; set; }
    
    /// <summary>
    /// Gets or sets the role type of the user.
    /// </summary>
    public RoleType Role { get; set; }
    
    /// <summary>
    /// Gets or sets the user-specific settings for notifications, etc.
    /// Nullable to indicate the possibility of no specific settings.
    /// </summary>
    public UserSettings? UserSettings { get; set; }
}
