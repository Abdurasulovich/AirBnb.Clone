namespace Airbnb.Application.Common.Identity.Models;

///<summary>
/// Represents the details required for user sign-in, including the email address and password.
///</summary>
public class SignInDetails
{
    ///<summary>
    /// Gets or sets the email address associated with the sign-in details.
    ///</summary>
    public string EmailAddress { get; set; } = default!;

    ///<summary>
    /// Gets or sets the password associated with the sign-in details.
    ///</summary>
    public string Password { get; set; } = default!;
}
