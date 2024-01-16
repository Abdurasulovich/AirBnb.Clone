using System.Collections.Immutable;
using System.Text;
using Airbnb.Application.Common.Identity.Models;
using Airbnb.Application.Common.Identity.Services.Interfaces;
using Airbnb.Domain.Entities;
using Airbnb.Domain.Extensions;
using Airbnb.Infrastructure.Settings;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace Airbnb.Infrastructure.Identity.Services;

///<summary>
/// Service for generating and validating passwords based on specified validation settings.
/// Initializes a new instance of the PasswordGeneratorService class.
///</summary>
///<param name="passwordValidationSettings">The settings for password validation.</param>
///<param name="credentialDetailsValidator">The validator for credential details.</param>
public class PasswordGeneratorService(
    IOptions<PasswordValidationSettings> passwordValidationSettings,
    IValidator<CredentialDetails> credentialDetailsValidator
    ) : IPasswordGeneratorService
{

    private readonly PasswordValidationSettings _passwordValidationSettings= passwordValidationSettings.Value;
    private readonly Random _random = new();
    
    ///<summary>
    /// Generates a random password based on the configured validation settings.
    ///</summary>
    ///<returns>A randomly generated and validated password.</returns>
    public string GeneratePassword()
    {
        var password = new StringBuilder();

        var requiredElements = GetRequiredElements();
        requiredElements.ForEach(element=>password.Append(GetPasswordElement(element)));

        while (password.Length < _passwordValidationSettings.MinimumLength)
            password.Append(GetPasswordElement((PasswordElementType)_random.Next(0, requiredElements.Count - 1)));

        var randomizedPassword = password.ToString().ToCharArray();
        _random.Shuffle(randomizedPassword);
        return new string(randomizedPassword);

    }

    ///<summary>
    /// Validates a provided password against user-specific criteria.
    ///</summary>
    ///<param name="password">The password to be validated.</param>
    ///<param name="user">The user for whom the password is being validated.</param>
    ///<returns>The validated password.</returns>
    public string GetValidatedPassword(string password, User user)
    {
        var validationContex = new ValidationContext<CredentialDetails>(
            new CredentialDetails
            {
                Password = password
            }
        )
        {
            RootContextData =
            {
                ["PersonalInformation"] = new[] { user.FirstName, user.LastName, user.EmailAddress }
            }
        };

        var validationResult = credentialDetailsValidator.Validate(validationContex);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        return password;
    }

    private ImmutableList<PasswordElementType> GetRequiredElements()
    {
        var requiredElements = new List<PasswordElementType>();
        
        if(_passwordValidationSettings.RequireDigit)
            requiredElements.Add(PasswordElementType.Digit);
        
        if(_passwordValidationSettings.RequireUppercase)
            requiredElements.Add(PasswordElementType.Lowercase);
        
        if(_passwordValidationSettings.RequireLowercase)
            requiredElements.Add(PasswordElementType.Lowercase);
        
        if(_passwordValidationSettings.RequireNonAlphanumeric)
            requiredElements.Add(PasswordElementType.NonAlphanumeric);

        return requiredElements.ToImmutableList();
    }


    private char GetPasswordElement(PasswordElementType passwordElementType)
    {
        return passwordElementType switch
        {
            PasswordElementType.Digit => CharExtensions.GetRandomDigit(_random),
            PasswordElementType.Uppercase => CharExtensions.GetRandomUppercase(_random),
            PasswordElementType.Lowercase => CharExtensions.GetRandomLowercase(_random),
            PasswordElementType.NonAlphanumeric => CharExtensions.GetRandomNonAlphanumeric(_random),
            _ => throw new ArgumentOutOfRangeException(nameof(passwordElementType), passwordElementType, null)
        };
    }
    
    private enum PasswordElementType
    {
        Digit=0,
        Uppercase = 1,
        Lowercase = 2,
        NonAlphanumeric = 3
    }
}