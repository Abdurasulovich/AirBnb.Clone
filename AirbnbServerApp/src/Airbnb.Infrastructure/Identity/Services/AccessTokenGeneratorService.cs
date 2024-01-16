using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Airbnb.Application.Common.Identity.Services.Interfaces;
using Airbnb.Domain.Constants;
using Airbnb.Domain.Entities;
using Airbnb.Identity.Domain.Entities;
using Airbnb.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Airbnb.Infrastructure.Identity.Services;

///<summary>
/// Service for generating access tokens based on user information and JWT settings.
/// Initializes a new instance of the AccessTokenGeneratorService class.
///</summary>
///<param name="jwtSettings">The JWT settings used for token generation.</param>
public class AccessTokenGeneratorService(IOptions<JwtSettings> jwtSettings) : IAccessTokenGeneratorService
{

    private readonly JwtSettings _jwtSettings = jwtSettings.Value;
    
    ///<summary>
    /// Generates an access token for the provided user.
    ///</summary>
    ///<param name="user">The user for whom the access token is generated.</param>
    ///<returns>An AccessToken containing the generated token and associated information.</returns>
    public AccessToken GetToken(User user)
    {
        var accessToken = new AccessToken
        {
            Id = Guid.NewGuid()
        };
        var jwtToken = GetJwtToken(user, accessToken);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        accessToken.Token = token;

        return accessToken;
    }

    ///<summary>
    /// Retrieves the ID from the provided access token string.
    ///</summary>
    ///<param name="accessToken">The access token from which to extract the ID.</param>
    ///<returns>The Guid representing the ID extracted from the access token.</returns>
    public Guid GetTokenId(string accessToken)
    {
        var tokenValue = accessToken.Split(' ')[1];
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(tokenValue);
        var tokenId = token.Claims.FirstOrDefault(c => c.Type == ClaimConstants.AccessTokenId)?.Value;

        if (string.IsNullOrEmpty(tokenId))
            throw new ArgumentException("Invalid access token");

        return Guid.Parse(tokenId);
    }

    private JwtSecurityToken GetJwtToken(User user, AccessToken accessToken)
    {
        var claims = GetClaims(user, accessToken);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            _jwtSettings.ValidIssuer,
            _jwtSettings.ValidAudience,
            claims,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
            credentials
            );
    }

    private List<Claim> GetClaims(User user, AccessToken accessToken)
    {
        return new List<Claim>
        {
            new(ClaimTypes.Email, user.EmailAddress),
            new(ClaimTypes.Role, user.Role.ToString()),
            new(ClaimConstants.UserId, user.Id.ToString()),
            new(ClaimConstants.AccessTokenId, accessToken.Id.ToString())
        };
    }
}
