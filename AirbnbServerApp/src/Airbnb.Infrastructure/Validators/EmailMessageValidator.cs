using Airbnb.Application.Common.Notifications.Models;
using Airbnb.Domain.Enums;
using FluentValidation;

namespace Airbnb.Infrastructure.Validators;

public class EmailMessageValidator : AbstractValidator<EmailMessage>
{
    public EmailMessageValidator()
    {
        RuleSet(
            NotificationProcessingEvent.OnRendering.ToString(),
            () =>
            {
                RuleFor(message => message.Template).NotNull();

                RuleFor(message => message.Variables).NotNull();

                RuleFor(message => message.Template.Content).NotNull().NotEmpty();
            }
        );

        RuleSet(
            NotificationProcessingEvent.OnSending.ToString(),
            () =>
            {
                RuleFor(message => message.ReceiverEmailAddress).NotNull().NotEmpty();

                RuleFor(message => message.Subject).NotNull().NotEmpty();

                RuleFor(message => message.Body).NotNull().NotEmpty();
            }
        );
    }
}