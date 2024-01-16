namespace Airbnb.Domain.Enums;

///<summary>
/// Enumeration representing different types of verifications.
///</summary>
public enum VerificationType
{
    ///<summary>
    /// Represents a verification code for user actions.
    ///</summary>
    UserActionVerificationCode = 0,

    ///<summary>
    /// Represents a verification code for user information.
    ///</summary>
    UserInfoVerificationCode = 1
}
