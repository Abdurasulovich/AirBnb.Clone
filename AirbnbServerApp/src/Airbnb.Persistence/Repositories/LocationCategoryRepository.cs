using Airbnb.Domain.Common.Caching;
using Airbnb.Domain.Entities;
using Airbnb.Persistence.Caching.Brokers.Interfaces;
using Airbnb.Persistence.DataContexts;
using Airbnb.Persistence.Repositories.Intefaces;
using System.Linq.Expressions;
using Airbnb.Domain.Common.Query;
using AirBnB.Domain.Common.Query;

namespace Airbnb.Persistence.Repositories;

public class LocationCategoryRepository(AirbnbDbContext airBnbDbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<LocationCategory, AirbnbDbContext>(airBnbDbContext, cacheBroker, new CacheEntryOptions()
    ), ILocationCategoryRepository
{
    public new IQueryable<LocationCategory> Get(Expression<Func<LocationCategory, bool>>? predicate = default,
        bool asNoTracking = false)
        => base.Get(predicate, asNoTracking);

    public new ValueTask<IList<LocationCategory>> GetAsync(
        QuerySpecification querySpecification,
        CancellationToken cancellationToken = default)
        => base.GetAsync(querySpecification, cancellationToken);

    public new ValueTask<IList<LocationCategory>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => base.GetByIdsAsync(ids, asNoTracking, cancellationToken);

    public new ValueTask<LocationCategory?> GetByIdAsync(Guid id, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => base.GetByIdAsync(id, asNoTracking, cancellationToken);

    public new ValueTask<LocationCategory> CreateAsync(LocationCategory locationCategory, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => base.CreateAsync(locationCategory, saveChanges, cancellationToken);

    public new ValueTask<LocationCategory> UpdateAsync(LocationCategory locationCategory, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => base.UpdateAsync(locationCategory, saveChanges, cancellationToken);

    public new ValueTask<bool> DeleteAsync(LocationCategory locationCategory, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => base.DeleteAsync(locationCategory, saveChanges, cancellationToken);

    public new ValueTask<bool> DeleteByIdAsync(Guid id, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => base.DeleteByIdAsync(id, saveChanges, cancellationToken);
}