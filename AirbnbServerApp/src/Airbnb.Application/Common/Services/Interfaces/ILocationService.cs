using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Application.Common.Services.Interfaces;

public interface ILocationService
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

    ValueTask<IList<Location>> GetByFilterAsync(
        QuerySpecification<Location> querySpecification,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        );

    ValueTask<Location?> GetByIdAsync(
        Guid locationId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        );

    ValueTask<IList<Location>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        );
}
