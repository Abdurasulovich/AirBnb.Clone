using Airbnb.Domain.Entities;
using Airbnb.Domain.Enums;

namespace Airbnb.Application.Common.Verifications.Services.Interfaces;

///<summary>
/// Defines the interface for a user verification code service, extending the verification code service.
///</summary>
public interface IUserInfoVerificationCoderService : IVerificationCodeService
{
    ///<summary>
    /// Generates a list of verification codes.
    ///</summary>
    ///<returns>The list of generated verification codes.</returns>
    IList<string> Generate();

    ///<summary>
    /// Asynchronously retrieves the user information verification code based on the provided code.
    ///</summary>
    ///<param name="code">The verification code to search for.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the user information verification code and a flag indicating its validity.</returns>
    ValueTask<(UserInfoVerificationCode Code, bool IsValid)> GetByCodeAsync(string code,
        CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously creates a user information verification code.
    ///</summary>
    ///<param name="codeType">The type of verification code to create.</param>
    ///<param name="userId">The unique identifier of the user associated with the verification code.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and containing the created user information verification code.</returns>
    ValueTask<UserInfoVerificationCode> CreateAsync(VerificationCodeType codeType, Guid userId,
        CancellationToken cancellationToken = default);

    ///<summary>
    /// Asynchronously deactivates a user information verification code.
    ///</summary>
    ///<param name="codeId">The unique identifier of the verification code to deactivate.</param>
    ///<param name="saveChanges">Flag indicating whether to save changes to the data store (default is true).</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation.</returns>
    ValueTask DeactivateAsync(Guid codeId, bool saveChanges = true, CancellationToken cancellationToken = default);
}
