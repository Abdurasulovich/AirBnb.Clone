using Airbnb.Application.Common.Identity.Services.Interfaces;
using Airbnb.Application.Common.Notifications.Events;
using Airbnb.Domain.Enums;
using FluentValidation;

namespace Airbnb.Infrastructure.Validators;

public class NotificationRequestValidator : AbstractValidator<ProcessNotificationEvent>
{
    public NotificationRequestValidator(IUserService userService)
    {
        var templateRequireSender = new List<NotificationTemplateType>
        {
            NotificationTemplateType.ReferrelNotification
        };

        RuleFor(request => request.SenderUserId)
            .NotEqual(Guid.Empty)
            .NotNull()
            .When(request => templateRequireSender.Contains(request.TemplateType))
            .CustomAsync(
                async (senderUserId, context, cancellationToken) =>
                {
                    var user = await userService.GetByIdAsync(senderUserId, true, cancellationToken);

                    if (user is null)
                        context.AddFailure("Sender user not found.");
                }
            );

        RuleFor(request => request.ReceiverUserId)
            .NotEqual(Guid.Empty)
            .CustomAsync(
                async (receiverUserId, context, cancellationToken) =>
                {
                    var user = await userService.GetByIdAsync(receiverUserId, true, cancellationToken);

                    if (user is null)
                        context.AddFailure("Receiver user not found.");
                }
            );
    }
}