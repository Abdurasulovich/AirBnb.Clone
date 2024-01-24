using Airbnb.Application.Common.Identity.Services.Interfaces;
using Airbnb.Application.Common.Verifications.Services.Interfaces;
using Airbnb.Domain.Enums;

namespace Airbnb.Infrastructure.Verifications.Services;

public class VerificationProcessingService(IUserInfoVerificationCoderService userInfoVerificationCoderService, IUserService userService)
    : IVerificationProcessingService
{
    public async ValueTask<bool> Verify(string code, CancellationToken cancellationToken = default)
    {
        var codeType = await userInfoVerificationCoderService.GetVerificationTypeAsync(code, cancellationToken) ??
                       throw new InvalidOperationException("Verification code is not found.");

        var result = codeType switch
        {
            VerificationType.UserActionVerificationCode => VerifyUserInfoAsync(code, cancellationToken),
            _ => throw new NotSupportedException("Verification type is not supported.")
        };

        return await result;
    }

    private async ValueTask<bool> VerifyUserInfoAsync(string code, CancellationToken cancellationToken = default)
    {
        var userInfoVerificationCode =
            await userInfoVerificationCoderService.GetByCodeAsync(code, cancellationToken: cancellationToken);
        if (!userInfoVerificationCode.IsValid) return false;

        var user = await userService.GetByIdAsync(userInfoVerificationCode.Code.UserId,
            cancellationToken: cancellationToken) ?? throw new InvalidOperationException();

        switch (userInfoVerificationCode.Code.CodeType)
        {
            case VerificationCodeType.EmailAddressVerification:
                user.IsEmailAddressVerified = true;
                await userService.UpdateAsync(user, false, cancellationToken);
                break;
            default: throw new NotSupportedException();
        }

        await userInfoVerificationCoderService.DeactivateAsync(userInfoVerificationCode.Code.Id,
            cancellationToken: cancellationToken);

        return true;
    }
}