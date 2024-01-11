using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using System.Linq.Expressions;
using AirBnB.Domain.Common.Query;

namespace Airbnb.Persistence.Repositories.Intefaces;

public interface ILocationCategoryRepository
{
    IQueryable<LocationCategory> Get(
        Expression<Func<LocationCategory, bool>>? predicate = default,
        bool asNoTracking = false
        );

    ValueTask<IList<LocationCategory>> GetAsync(
        QuerySpecification<LocationCategory> querySpecification,
        CancellationToken cancellationToken = default
        );

    ValueTask<IList<LocationCategory>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        );

    ValueTask<LocationCategory?> GetByIdAsync(
        Guid id,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        );
    
    ValueTask<LocationCategory> CreateAsync(
        LocationCategory locationCategory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );

    ValueTask<LocationCategory> UpdateAsync(
        LocationCategory locationCategory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );

    ValueTask<bool> DeleteAsync(
        LocationCategory locationCategory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );

    ValueTask<bool> DeleteByIdAsync(
        Guid id,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}
