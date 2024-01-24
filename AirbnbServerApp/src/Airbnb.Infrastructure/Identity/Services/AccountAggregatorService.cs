using Airbnb.Application.Common.EventBus.Brokers.Interfaces;
using Airbnb.Application.Common.Identity.Services.Interfaces;
using Airbnb.Application.Common.Notifications.Events;
using Airbnb.Application.Common.Notifications.Models;
using Airbnb.Application.Common.Verifications.Services.Interfaces;
using Airbnb.Domain.Constants;
using Airbnb.Domain.Entities;
using Airbnb.Domain.Enums;
using Airbnb.Persistence.Repositories.Interfaces;

namespace Airbnb.Infrastructure.Identity.Services;

///<summary>
/// Service for aggregating account-related operations, such as user creation and email verification.
/// Initializes a new instance of the AccountAggregatorService class.
///</summary>
///<param name="userService">The service for user-related operations.</param>
///<param name="userSettingsService">The service for user settings-related operations.</param>
///<param name="userInfoVerificationCoderService">The service for generating user verification codes.</param>
///<param name="eventBusBroker">The event bus broker for publishing events.</param>
public class AccountAggregatorService(
    IUserService userService, 
    IUserSettingsService userSettingsService, 
    IUserInfoVerificationCoderService userInfoVerificationCoderService, 
    IEventBusBroker eventBusBroker)
    : IAccountAggregatorService
{
    
    ///<summary>
    /// Creates a user asynchronously and performs associated actions, such as sending welcome and verification emails.
    ///</summary>
    ///<param name="user">The user object to be created.</param>
    ///<param name="cancellationToken">A cancellation token to cancel the operation.</param>
    ///<returns>A ValueTask representing the asynchronous operation, returning true if the user is successfully created.</returns>
    public async ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default)
    {
        user.Role = RoleType.User;
        var createUser = await userService.CreateAsync(user, cancellationToken: cancellationToken);
        await userSettingsService.CreateAsync(
            new UserSettings
            {
                Id = createUser.Id
            },
            cancellationToken: cancellationToken
            );

        
        //send welcome email
        var welcomeNotificationEvent = new ProcessNotificationEvent
        {
            ReceiverUserId = createUser.Id,
            TemplateType = NotificationTemplateType.WelcomeNotification,
            Variables = new Dictionary<string, string>
            {
                { NotificationTemplateConstants.UserNamePlaceholder, createUser.FirstName }
            }
        };
        
        //send verification email
        await eventBusBroker.PublishAsync(
            welcomeNotificationEvent,
            EventBusConstants.NotificationExchangeName,
            EventBusConstants.ProcessNotificationQueueName,
            cancellationToken
        );

        var verificationCode = await userInfoVerificationCoderService.CreateAsync(
            VerificationCodeType.EmailAddressVerification,
            createUser.Id,
            cancellationToken
            );
        //send verification email
        var sendVerificationEmail = new EmailProcessNotificationEvent
        {
            ReceiverUserId = createUser.Id,
            TemplateType = NotificationTemplateType.EmailAddressVerificationNotification,
            Variables = new Dictionary<string, string>
            {
                {
                    NotificationTemplateConstants.EmailAddressVerificationLinkPlaceholder,
                    verificationCode.VerificationLink
                }
            }
        };

        await eventBusBroker.PublishAsync(
            sendVerificationEmail,
            EventBusConstants.NotificationExchangeName,
            EventBusConstants.ProcessNotificationQueueName,
            cancellationToken
        );

        return true;

    }
}