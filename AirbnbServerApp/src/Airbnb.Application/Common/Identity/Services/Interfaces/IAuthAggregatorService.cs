using Airbnb.Application.Common.Identity.Models;

namespace Airbnb.Application.Common.Identity.Services.Interfaces;

///<summary>
/// Defines the interface for an authentication aggregator service.
///</summary>
public interface IAuthAggregatorService
{
    ///<summary>
    /// Asynchronously performs user sign-up using the provided sign-up details.
    ///</summary>
    ///<param name="signUpDetails">The details required for user sign-up.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous operation and indicating whether the sign-up was successful.</returns>
    ValueTask<bool> SignUpAsync(SignUpDetails signUpDetails, CancellationToken cancellationToken = default);
}
