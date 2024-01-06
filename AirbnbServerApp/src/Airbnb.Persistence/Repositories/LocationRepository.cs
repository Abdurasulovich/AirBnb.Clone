using Airbnb.Domain.Common.Caching;
using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using Airbnb.Persistence.Caching.Brokers.Interfaces;
using Airbnb.Persistence.DataContexts;
using Airbnb.Persistence.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Airbnb.Persistence.Repositories;

public class LocationRepository(AirbnbDbContext airBnbDbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<Location, AirbnbDbContext>(airBnbDbContext, cacheBroker, new CacheEntryOptions()
    ), ILocationRepository
{
    IQueryable<Location> ILocationRepository.Get(Expression<Func<Location, bool>>? predicate, bool asNoTracking)
        =>base.Get(predicate, asNoTracking);

    async ValueTask<IList<Location>> ILocationRepository.GetAsync(QuerySpecification<Location> querySpecification, bool asNoTracking, CancellationToken cancellationToken)
    {
        var test = await DbContext.Locations.Include(x => x.Category).Where(x => x.Category!.Name.Equals("Castle"))
            .ToListAsync(cancellationToken: cancellationToken);

        var locations = await base.GetAsync(querySpecification, asNoTracking, cancellationToken);
        return locations;
    }

    ValueTask<Location?> ILocationRepository.GetByIdAsync(Guid locationId, bool asNoTracking, CancellationToken cancellationToken)
        =>base.GetByIdAsync(locationId, asNoTracking, cancellationToken);

    ValueTask<IList<Location>> ILocationRepository.GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking, CancellationToken cancellationToken)
        => base.GetByIdsAsync(ids, asNoTracking, cancellationToken);
}