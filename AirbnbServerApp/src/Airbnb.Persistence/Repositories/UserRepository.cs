using System.Linq.Expressions;
using AirBnB.Domain.Common.Query;
using Airbnb.Domain.Entities;
using Airbnb.Persistence.Caching.Brokers.Interfaces;
using Airbnb.Persistence.DataContexts;
using Airbnb.Persistence.Repositories.Interfaces;

namespace Airbnb.Persistence.Repositories;

///<summary>
/// Implementation of the IUserRepository interface for managing user information verification code-related data operations.
///</summary>
///<summary>
/// Initializes a new instance of the UserRepository class with the specified database context and cache broker.
///</summary>
///<param name="dbContext">The database context for accessing the underlying storage.</param>
///<param name="cacheBroker">The cache broker for handling caching operations.</param>

public class UserRepository(IdentityDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<User, IdentityDbContext>(dbContext, cacheBroker), IUserRepository
{
    ///<inheritdoc/>
    public new IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    ///<inheritdoc/>
    public new ValueTask<IList<User>> GetAsync(QuerySpecification<User> querySpecification, CancellationToken cancellationToken = default)
    {
        return base.GetAsync(querySpecification, cancellationToken);
    }

    ///<inheritdoc/>
    public new ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }

    ///<inheritdoc/>
    public new ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(user, saveChanges, cancellationToken);
    }

    ///<inheritdoc/>
    public new ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(user, saveChanges, cancellationToken);
    }
}