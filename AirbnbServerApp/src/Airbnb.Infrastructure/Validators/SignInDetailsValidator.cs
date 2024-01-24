using Airbnb.Application.Common.Identity.Models;
using Airbnb.Infrastructure.Settings;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace Airbnb.Infrastructure.Validators;

public class SignInDetailsValidator : AbstractValidator<SignInDetails>
{
    public SignInDetailsValidator(IOptions<ValidationSettings> validationSettings)
    {
        var validationSettingsValue = validationSettings.Value;

        RuleFor(sign => sign.EmailAddress).NotEmpty().Matches(validationSettingsValue.EmailAddressRegexPattern);

        RuleFor(signin => signin.Password).NotEmpty();
    }
}