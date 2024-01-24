using Airbnb.Domain.Entities;
using Airbnb.Domain.Enums;
using FluentValidation;

namespace Airbnb.Infrastructure.Validators;

public class EmailTemplateValidator : AbstractValidator<EmailTemplate>
{
    public EmailTemplateValidator()
    {
        RuleFor(template => template.Content)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(256);

        RuleFor(template => template.Type).Equal(NotificationType.Email);
    }
}