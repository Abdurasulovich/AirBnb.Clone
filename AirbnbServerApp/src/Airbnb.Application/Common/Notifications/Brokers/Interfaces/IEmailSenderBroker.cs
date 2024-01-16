using Airbnb.Application.Common.Notifications.Models;

namespace Airbnb.Application.Common.Notifications.Brokers.Interfaces;

///<summary>
/// Defines the interface for an email sender broker.
///</summary>
public interface IEmailSenderBroker
{
    ///<summary>
    /// Asynchronously sends an email message.
    ///</summary>
    ///<param name="emailMessage">The email message to send.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and indicating whether the email was sent successfully.</returns>
    ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}
