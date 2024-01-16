using Airbnb.Domain.Enums;

namespace Airbnb.Domain.Entities;

///<summary>
/// Represents a verification code specific to user information.
/// Inherits from the base VerificationCode class.
///</summary>
public class UserInfoVerificationCode : VerificationCode
{
    ///<summary>
    /// Constructor initializing the verification type to UserInfoVerificationCode.
    ///</summary>
    public UserInfoVerificationCode()
    {
        Type = VerificationType.UserInfoVerificationCode;
    }
    
    ///<summary>
    /// Gets or sets the unique identifier of the user associated with the verification code.
    ///</summary>
    public Guid UserId { get; set; }
}
