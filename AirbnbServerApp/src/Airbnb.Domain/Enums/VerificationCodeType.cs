namespace Airbnb.Domain.Enums;

///<summary>
/// Enumeration representing different types of verification codes.
///</summary>
public enum VerificationCodeType
{
    ///<summary>
    /// Represents an email address verification code.
    ///</summary>
    EmailAddressVerification,

    ///<summary>
    /// Represents a phone number verification code.
    ///</summary>
    PhoneNumberVerification,

    ///<summary>
    /// Represents an account deletion verification code.
    ///</summary>
    AccountDeleteVerification
}
