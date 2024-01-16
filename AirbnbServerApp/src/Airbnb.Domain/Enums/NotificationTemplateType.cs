namespace Airbnb.Domain.Enums;

///<summary>
/// Enumeration representing different types of notification templates.
///</summary>
public enum NotificationTemplateType
{
    ///<summary>
    /// Represents a welcome notification template.
    ///</summary>
    WelcomeNotification = 0,

    ///<summary>
    /// Represents an email address verification notification template.
    ///</summary>
    EmailAddressVerificationNotification = 1,

    ///<summary>
    /// Represents a phone number verification notification template.
    ///</summary>
    PhoneNumberVerificateionNotification = 2,

    ///<summary>
    /// Represents a referral notification template.
    ///</summary>
    ReferrelNotification = 3
}
