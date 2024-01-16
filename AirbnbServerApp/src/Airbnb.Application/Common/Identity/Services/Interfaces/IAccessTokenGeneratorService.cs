using Airbnb.Domain.Entities;
using Airbnb.Identity.Domain.Entities;

namespace Airbnb.Application.Common.Identity.Services.Interfaces;

///<summary>
/// Defines the interface for an access token generator service.
///</summary>
public interface IAccessTokenGeneratorService
{
    ///<summary>
    /// Generates an access token for the specified user.
    ///</summary>
    ///<param name="user">The user for whom the access token is generated.</param>
    ///<returns>The generated access token.</returns>
    AccessToken GetToken(User user);

    ///<summary>
    /// Retrieves the unique identifier of an access token based on its string representation.
    ///</summary>
    ///<param name="accessToken">The string representation of the access token.</param>
    ///<returns>The unique identifier of the access token.</returns>
    Guid GetTokenId(string accessToken);
}
