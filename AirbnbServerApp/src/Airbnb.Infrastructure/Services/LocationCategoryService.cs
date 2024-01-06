using Airbnb.Application.Common.Services.Interfaces;
using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using Airbnb.Persistence.Repositories.Intefaces;
using System.Linq.Expressions;

namespace Airbnb.Infrastructure.Services;

public class LocationCategoryService(ILocationCategoryRepository locationCategoryRepository) : ILocationCategoryService
{
    public IQueryable<LocationCategory> Get(Expression<Func<LocationCategory, bool>>? predicate = null, bool asNoTracking = false)
        => locationCategoryRepository.Get(predicate, asNoTracking);

    public async ValueTask<IList<LocationCategory>> GetAsync(QuerySpecification<LocationCategory> querySpecification, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await locationCategoryRepository.GetAsync(querySpecification, asNoTracking, cancellationToken);

    public async ValueTask<LocationCategory?> GetByIdAsync(Guid locationCategoryId, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await locationCategoryRepository.GetByIdAsync(locationCategoryId, asNoTracking, cancellationToken);   

    public async ValueTask<IList<LocationCategory>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await locationCategoryRepository.GetByIdsAsync(ids, asNoTracking, cancellationToken);
}