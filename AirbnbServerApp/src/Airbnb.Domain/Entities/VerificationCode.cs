
using Airbnb.Domain.Common.Entities;
using Airbnb.Domain.Enums;

namespace Airbnb.Domain.Entities;

/// <summary>
/// Represents the base properties of a verification code entity.
/// </summary>
public abstract class VerificationCode : Entity
{
    /// <summary>
    /// Gets or sets the type of the verification code.
    /// </summary>
    public VerificationCodeType CodeType { get; set; }
    
    /// <summary>
    /// Gets or sets the type of verification.
    /// </summary>
    public VerificationType Type { get; set; }
    
    /// <summary>
    /// Gets or sets the expiry time of the verification code.
    /// </summary>
    public DateTimeOffset ExpiryTime { get; set; }
    
    /// <summary>
    /// Gets or sets a flag indicating whether the verification code is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the actual verification code value.
    /// Initialized to default non-null value.
    /// </summary>
    public string Code { get; set; } = default!;

    /// <summary>
    /// Gets or sets the verification link associated with the code.
    /// Initialized to default non-null value.
    /// </summary>
    public string VerificationLink { get; set; } = default!;
}
