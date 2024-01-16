using Airbnb.Domain.Entities;

namespace Airbnb.Application.Common.Identity.Services.Interfaces;

///<summary>
/// Defines the interface for a password generator service.
///</summary>
public interface IPasswordGeneratorService
{
    ///<summary>
    /// Generates a random password.
    ///</summary>
    ///<returns>The generated password.</returns>
    string GeneratePassword();

    ///<summary>
    /// Validates and retrieves a password based on specified rules for a given user.
    ///</summary>
    ///<param name="password">The password to validate and retrieve.</param>
    ///<param name="user">The user for whom the password is being validated and retrieved.</param>
    ///<returns>The validated and potentially modified password.</returns>
    string GetValidatedPassword(string password, User user);
}
