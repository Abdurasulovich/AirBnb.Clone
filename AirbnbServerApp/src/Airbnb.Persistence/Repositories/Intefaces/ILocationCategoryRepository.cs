using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using System.Linq.Expressions;

namespace Airbnb.Persistence.Repositories.Intefaces;

public interface ILocationCategoryRepository
{
    IQueryable<LocationCategory> Get(
        Expression<Func<LocationCategory, bool>>? predicate = default,
        bool asNoTracking = false
        );

    ValueTask<IList<LocationCategory>> GetAsync(
        QuerySpecification<LocationCategory> querySpecification,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        );

    ValueTask<IList<LocationCategory>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        );

    ValueTask<LocationCategory?> GetByIdAsync(
        Guid locationId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        );
}
