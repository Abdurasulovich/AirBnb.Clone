using System.Security.Cryptography;
using Airbnb.Application.Common.Notifications.Models;
using Airbnb.Domain.Common.Exceptions;

namespace Airbnb.Application.Common.Notifications.Services.Interfaces;

///<summary>
/// Defines the interface for an email orchestration service.
///</summary>
public interface IEmailOrchestrationService
{
    ///<summary>
    /// Asynchronously orchestrates the sending of an email based on the provided process notification event.
    ///</summary>
    ///<param name="event">The process notification event containing information about the email to be sent.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the result of the email sending orchestration.</returns>
    ValueTask<FuncResult<bool>> SendAsync(
        EmailProcessNotificationEvent @event,
        CancellationToken cancellationToken = default);
}
