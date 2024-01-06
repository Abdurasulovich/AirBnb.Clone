using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using System.Linq.Expressions;
using AirBnB.Domain.Common.Query;

namespace Airbnb.Persistence.Repositories.Intefaces;

public interface ILocationRepository
{
    IQueryable<Location> Get(
        Expression<Func<Location, bool>>? predicate = default,
        bool asNoTracking = false
        );
    ValueTask<IList<Location>> GetAsync(
        QuerySpecification querySpecification,
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
    
    ValueTask<Location> CreateAsync(
        Location location,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );

    ValueTask<Location> UpdateAsync(
        Location location,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );

    ValueTask<bool> DeleteAsync(
        Location location,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );

    ValueTask<bool> DeleteByIdAsync(
        Guid id,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}
