using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using System.Linq.Expressions;

namespace Airbnb.Persistence.Repositories.Intefaces;

public interface ILocationRepository
{
    IQueryable<Location> Get(
        Expression<Func<Location, bool>>? predicate = default,
        bool asNoTracking = false
        );
    ValueTask<IList<Location>> GetAsync(
        QuerySpecification<Location> querySpecification,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        );

    ValueTask<IList<Location>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        );

    ValueTask<Location?> GetByIdAsync(
        Guid locationId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        );
}
