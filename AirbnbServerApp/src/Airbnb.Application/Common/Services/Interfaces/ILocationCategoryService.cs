using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Application.Common.Services.Interfaces;

public interface ILocationCategoryService
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
        Guid locationCategoryId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        );
}
