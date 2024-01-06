using Airbnb.Domain.Common.Caching;
using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using Airbnb.Persistence.Caching.Brokers.Interfaces;
using Airbnb.Persistence.DataContexts;
using Airbnb.Persistence.Repositories.Intefaces;
using System.Linq.Expressions;

namespace Airbnb.Persistence.Repositories;

public class LocationCategoryRepostiory(AirbnbDbContext airBnbDbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<LocationCategory, AirbnbDbContext>(airBnbDbContext, cacheBroker, new CacheEntryOptions()
    ), ILocationCategoryRepository
{
    public new IQueryable<LocationCategory> Get(Expression<Func<LocationCategory, bool>>? predicate, bool asNoTracking)
        => base.Get(predicate, asNoTracking);

    public new ValueTask<IList<LocationCategory>> GetAsync(QuerySpecification<LocationCategory> querySpecification, bool asNoTracking, CancellationToken cancellationToken)
        => base.GetAsync(querySpecification, asNoTracking, cancellationToken);

    public new ValueTask<LocationCategory?> GetByIdAsync(Guid locationId, bool asNoTracking, CancellationToken cancellationToken)
        => base.GetByIdAsync(locationId, asNoTracking, cancellationToken);

    public new ValueTask<IList<LocationCategory>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking, CancellationToken cancellationToken)
        => base.GetByIdsAsync(ids, asNoTracking, cancellationToken);
}