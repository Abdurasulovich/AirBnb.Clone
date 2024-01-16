namespace Airbnb.Application.Common.Identity.Models;

///<summary>
/// Represents the details required for user sign-up, including the first name, last name, email address, birth date,
/// password, and an option for auto-generating the password.
///</summary>
public class SignUpDetails
{
    ///<summary>
    /// Gets or sets the first name associated with the sign-up details.
    ///</summary>
    public string FirsName { get; set; } = default!;

    ///<summary>
    /// Gets or sets the last name associated with the sign-up details.
    ///</summary>
    public string LastName { get; set; } = default!;

    ///<summary>
    /// Gets or sets the email address associated with the sign-up details.
    ///</summary>
    public string EmailAddress { get; set; } = default!;
    
    ///<summary>
    /// Gets or sets the birth date associated with the sign-up details.
    ///</summary>
    public DateTime BirthDate { get; set; }
    
    ///<summary>
    /// Gets or sets the password associated with the sign-up details. Can be null if auto-generating the password.
    ///</summary>
    public string? Password { get; set; }
    
    ///<summary>
    /// Gets or sets a boolean indicating whether to auto-generate the password.
    ///</summary>
    public bool AutoGeneratePassword { get; set; }
}
