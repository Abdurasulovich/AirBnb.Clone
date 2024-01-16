using Airbnb.Application.Common.Notifications.Models;

namespace Airbnb.Application.Common.Notifications.Services.Interfaces;

///<summary>
/// Defines the interface for an email rendering service.
///</summary>
public interface IEmailRenderingService
{
    ///<summary>
    /// Asynchronously renders an email message to produce the email body.
    ///</summary>
    ///<param name="emailMessage">The email message to render.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the rendered email body.</returns>
    ValueTask<string> RenderAsync(
        EmailMessage emailMessage,
        CancellationToken cancellationToken = default);
}
