using Airbnb.Domain.Common.Caching;
using Airbnb.Domain.Common.Entities;
using Airbnb.Domain.Common.Entities.Interfaces;
using Airbnb.Domain.Comparers;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Airbnb.Domain.Common.Query;

public class QuerySpecification<TEntity>(uint pageSize, uint pageToken, int? hashCode = default): CacheModel where TEntity: IEntity
{
    public List<Expression<Func<TEntity, bool>>> FilteringOptions { get; } = [];

    public List<Expression<Func<TEntity, object>>> IncludeOptions { get; } = [];

    public List<(Expression<Func<TEntity, object>> KeySelector, bool isAscending)> OrderingOptions { get; } = [];

    public FilterPagination PaginationOptions { get; set; } = new(pageSize, pageToken);

    public int? FilterHashCode { get; set; } = hashCode;

    public override int GetHashCode()
    {
        if(FilterHashCode.HasValue) return FilterHashCode.Value;

        var expressionEqualityComperer = ExpressionEqualityComparer.Instance;
        var hashCode = new HashCode();

        var test = expressionEqualityComperer.GetHashCode(FilteringOptions[0]);

        foreach (var filter in FilteringOptions.Order(new PredicateExpressionComparer<TEntity>()))
            hashCode.Add(expressionEqualityComperer.GetHashCode(filter));

        foreach(var filter in OrderingOptions)
        {
            hashCode.Add(expressionEqualityComperer.GetHashCode(filter.KeySelector));
            hashCode.Add(filter.isAscending);
        }

        hashCode.Add(PaginationOptions);

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj is QuerySpecification<TEntity> querySpecification &&
            querySpecification.GetHashCode() == GetHashCode();
    }

    public override string CacheKey => $"{typeof(TEntity).Name}_{GetHashCode()}";
}