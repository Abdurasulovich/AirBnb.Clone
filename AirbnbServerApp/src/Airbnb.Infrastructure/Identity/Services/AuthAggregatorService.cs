using Airbnb.Application.Common.Identity.Models;
using Airbnb.Application.Common.Identity.Services.Interfaces;
using Airbnb.Domain.Entities;
using AutoMapper;

namespace Airbnb.Infrastructure.Identity.Services;

///<summary>
/// Service for aggregating authentication-related operations, such as user registration.
/// Initializes a new instance of the AuthAggregatorService class.
///</summary>
///<param name="mapper">The AutoMapper instance for object mapping.</param>
///<param name="passwordGeneratorService">The service for generating passwords.</param>
///<param name="passwordHasherService">The service for hashing passwords.</param>
///<param name="accountAggregatorService">The service for aggregating account-related operations.</param>
///<param name="userService">The service for user-related operations.</param>
public class AuthAggregatorService(
    IMapper mapper,
    IPasswordGeneratorService passwordGeneratorService,
    IPasswordHasherService passwordHasherService,
    IAccountAggregatorService accountAggregatorService,
    IUserService userService
    ): IAuthAggregatorService
{
    
    ///<summary>
    /// Signs up a user asynchronously with the provided sign-up details.
    ///</summary>
    ///<param name="signUpDetails">The details for user registration.</param>
    ///<param name="cancellationToken">A cancellation token to cancel the operation.</param>
    ///<returns>A ValueTask representing the asynchronous operation, returning true if the user is successfully registered.</returns>
    public async ValueTask<bool> SignUpAsync(SignUpDetails signUpDetails, CancellationToken cancellationToken = default)
    {
        var foundUserId = await userService.GetIdByEmailAddressAsync(signUpDetails.EmailAddress, cancellationToken);

        if (foundUserId.HasValue)
            throw new InvalidOperationException("User already exist");
        
        //Hash password
        var user = mapper.Map<User>(signUpDetails);
        var password = signUpDetails.AutoGeneratePassword
            ? passwordGeneratorService.GeneratePassword()
            : passwordGeneratorService.GetValidatedPassword(signUpDetails.Password!, user);

        user.PasswordHash = passwordHasherService.HashPassword(password);
        
        //Create user
        return await accountAggregatorService.CreateUserAsync(user, cancellationToken);
    }
}