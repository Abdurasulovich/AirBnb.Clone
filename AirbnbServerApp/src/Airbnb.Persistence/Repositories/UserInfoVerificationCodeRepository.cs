using System.Linq.Expressions;
using Airbnb.Domain.Entities;
using Airbnb.Domain.Enums;
using Airbnb.Persistence.Caching.Brokers.Interfaces;
using Airbnb.Persistence.DataContexts;
using Airbnb.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Persistence.Repositories;

///<summary>
/// Implementation of the IUserInfoVerificationCodeRepository interface for managing user information verification code-related data operations.
///</summary>
///<summary>
/// Initializes a new instance of the UserInfoVerificationCodeRepository class with the specified database context and cache broker.
///</summary>
///<param name="dbContext">The database context for accessing the underlying storage.</param>
///<param name="cacheBroker">The cache broker for handling caching operations.</param>

public class UserInfoVerificationCodeRepository(IdentityDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<UserInfoVerificationCode, IdentityDbContext>(dbContext, cacheBroker), IUserInfoVerificationCodeRepository
{
    
    ///<inheritdoc/>
    public new IQueryable<UserInfoVerificationCode> Get(Expression<Func<UserInfoVerificationCode, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    ///<inheritdoc/>
    public new ValueTask<UserInfoVerificationCode?> GetByIdAsync(Guid codeId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(codeId, asNoTracking, cancellationToken);
    }

    ///<inheritdoc/>
    public new async ValueTask<UserInfoVerificationCode> CreateAsync(UserInfoVerificationCode userInfoVerificationCode, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        await DbContext.UserInfoVerificationCodes.Where(code =>
                code.UserId == userInfoVerificationCode.UserId && code.CodeType == userInfoVerificationCode.CodeType)
            .ExecuteUpdateAsync(setter => setter.SetProperty(code => code.IsActive, false), cancellationToken);

        return await base.CreateAsync(userInfoVerificationCode, saveChanges, cancellationToken);
    }

    public async ValueTask DeactivateAsync(Guid codeId, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        await DbContext.UserInfoVerificationCodes.Where(code => code.Id == codeId)
            .ExecuteUpdateAsync(setter => setter.SetProperty(code => code.IsActive, false), cancellationToken);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);
    }
}