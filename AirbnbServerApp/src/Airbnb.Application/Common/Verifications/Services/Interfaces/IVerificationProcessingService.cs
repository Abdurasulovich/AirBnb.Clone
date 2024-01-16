namespace Airbnb.Application.Common.Verifications.Services.Interfaces;

///<summary>
/// Defines the interface for a verification processing service.
///</summary>
public interface IVerificationProcessingService
{
    ///<summary>
    /// Asynchronously verifies a code.
    ///</summary>
    ///<param name="code">The verification code to verify.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and indicating whether the verification was successful.</returns>
    ValueTask<bool> Verify(string code, CancellationToken cancellationToken = default);
}
