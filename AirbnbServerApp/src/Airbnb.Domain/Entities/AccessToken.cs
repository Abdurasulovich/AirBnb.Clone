using Airbnb.Domain.Common.Entities;

namespace Airbnb.Identity.Domain.Entities;

///<summary>
/// Represents an access token entity used for authentication.
/// Inherits from the Entity class.
///</summary>
public class AccessToken : Entity
{
    ///<summary>
    /// Default constructor.
    ///</summary>
    public AccessToken()
    {
    }

    ///<summary>
    /// Parameterized constructor to initialize properties of the access token.
    ///</summary>
    ///<param name="id">Unique identifier for the access token.</param>
    ///<param name="userId">Unique identifier for the associated user.</param>
    ///<param name="token">The access token value.</param>
    ///<param name="expiryTime">The expiration time of the access token.</param>
    ///<param name="isRevoked">Flag indicating whether the access token is revoked.</param>
    public AccessToken(Guid id, Guid userId, string token, DateTimeOffset expiryTime, bool isRevoked)
    {
        Id = id;
        UserId = userId;
        Token = token;
        ExpiryTime = expiryTime;
        IsRevoked = isRevoked;
    }
    
    ///<summary>
    /// Gets or sets the unique identifier of the associated user.
    ///</summary>
    public Guid UserId { get; set; }

    ///<summary>
    /// Gets or sets the value of the access token.
    ///</summary>
    public string Token { get; set; } = default!;
    
    ///<summary>
    /// Gets or sets the expiration time of the access token.
    ///</summary>
    public DateTimeOffset ExpiryTime { get; set; }
    
    ///<summary>
    /// Gets or sets a flag indicating whether the access token is revoked.
    ///</summary>
    public bool IsRevoked { get; set; }
}
