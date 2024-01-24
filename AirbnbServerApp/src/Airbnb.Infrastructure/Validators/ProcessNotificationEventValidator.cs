using Airbnb.Application.Common.Notifications.Events;
using FluentValidation;

namespace Airbnb.Infrastructure.Validators;

public class ProcessNotificationEventValidator : AbstractValidator<ProcessNotificationEvent>
{
    public ProcessNotificationEventValidator()
    {
        RuleFor(process => process.ReceiverUserId).NotEqual(Guid.Empty);
    }
}