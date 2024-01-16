namespace Airbnb.Application.Common.Identity.Services.Interfaces;

///<summary>
/// Defines the interface for a password hasher service.
///</summary>
public interface IPasswordHasherService
{
    ///<summary>
    /// Hashes the provided password.
    ///</summary>
    ///<param name="password">The password to hash.</param>
    ///<returns>The hashed password.</returns>
    string HashPassword(string password);

    ///<summary>
    /// Validates a password against its hashed counterpart.
    ///</summary>
    ///<param name="password">The plain-text password to validate.</param>
    ///<param name="hashedPassword">The hashed password to compare against.</param>
    ///<returns>True if the password is valid; otherwise, false.</returns>
    bool ValidatePassword(string password, string hashedPassword);
}
