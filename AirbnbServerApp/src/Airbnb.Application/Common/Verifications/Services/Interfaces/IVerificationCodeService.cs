using Airbnb.Domain.Enums;

namespace Airbnb.Application.Common.Verifications.Services.Interfaces;

///<summary>
/// Defines the interface for a verification code service.
///</summary>
public interface IVerificationCodeService
{
    ///<summary>
    /// Asynchronously retrieves the verification type associated with a verification code.
    ///</summary>
    ///<param name="code">The verification code for which to retrieve the verification type.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the verification type or null if not found.</returns>
    ValueTask<VerificationType?> GetVerificationTypeAsync(string code, CancellationToken cancellationToken = default);
}
