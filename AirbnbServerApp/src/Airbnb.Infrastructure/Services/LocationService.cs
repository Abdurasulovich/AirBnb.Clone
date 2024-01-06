using Airbnb.Application.Common.Services.Interfaces;
using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using Airbnb.Persistence.Repositories.Intefaces;
using System.Linq.Expressions;

namespace Airbnb.Infrastructure.Services;

public class LocationService(ILocationRepository locationRepository) : ILocationService
{
    public IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = null, bool asNoTracking = false)
        => locationRepository.Get(predicate, asNoTracking);

    public ValueTask<IList<Location>> GetAsync(QuerySpecification<Location> querySpecification, bool asNoTracking = false, CancellationToken cancellationToken = default)
        =>locationRepository.GetAsync(querySpecification, asNoTracking, cancellationToken);

    public async ValueTask<IList<Location>> GetByFilterAsync(QuerySpecification<Location> querySpecification, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await locationRepository.GetAsync(querySpecification, asNoTracking, cancellationToken);

    public async ValueTask<Location?> GetByIdAsync(Guid locationId, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await locationRepository.GetByIdAsync(locationId, asNoTracking, cancellationToken);

    public async ValueTask<IList<Location>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await locationRepository.GetByIdsAsync(ids, asNoTracking, cancellationToken);
}