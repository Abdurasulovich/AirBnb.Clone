using System.Linq.Expressions;
using Airbnb.Domain.Common.Caching;
using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Comparers;
using Microsoft.EntityFrameworkCore.Query;

namespace AirBnB.Domain.Common.Query;

///<summary>
/// Represents a generic query specification for filtering, ordering, and pagination of entities.
/// Implements the ICacheModel interface.
///</summary>
public class QuerySpecification<TSource>(uint pageSize, uint pageToken, bool asNoTracking, int? filterHashCode =default) : ICacheModel
{
    ///<summary>
    /// Gets the list of filtering options specified for the query.
    ///</summary>
    public List<Expression<Func<TSource, bool>>> FilteringOptions { get; } = [];

    ///<summary>
    /// Gets the list of ordering options specified for the query.
    ///</summary>
    public List<(Expression<Func<TSource, object>> KeySelector, bool IsAscending)> OrderingOptions { get; } = [];
    
    ///<summary>
    /// Gets the list of including options specified for the query.
    ///</summary>
    public List<Expression<Func<TSource, object>>> IncludingOptions { get; } = [];

    ///<summary>
    /// Gets the pagination options specified for the query.
    ///</summary>
    public FilterPagination PaginationOptions { get; } = new()
    {
        PageSize = pageSize,
        PageToken = pageToken
    };

    ///<summary>
    /// Gets a flag indicating whether to use no-tracking for the query.
    ///</summary>
    public bool AsNoTracking { get; } = asNoTracking;

    ///<summary>
    /// Gets the hash code associated with the filtering options.
    ///</summary>
    public int? FilterHashCode { get; } = filterHashCode;

    ///<summary>
    /// Gets the cache key for the query specification.
    ///</summary>
    public string CacheKey => $"{typeof(TSource).Name}_{GetHashCode()}";

    ///<summary>
    /// Calculates the hash code based on filtering, ordering, and pagination options.
    ///</summary>
    public override int GetHashCode()
    {
        if (FilterHashCode is not null) return FilterHashCode.Value;
        
        var hashCode = new HashCode();
        var expressionEqualityComparer = ExpressionEqualityComparer.Instance;

        foreach (var filter in FilteringOptions.Order(new PredicateExpressionComparer<TSource>()))
            hashCode.Add(expressionEqualityComparer.GetHashCode(filter));

        foreach (var include in IncludingOptions.Order(new KeySelectorExpressionComparer<TSource>()))
            hashCode.Add(expressionEqualityComparer.GetHashCode(include));

        foreach (var order in OrderingOptions)
            hashCode.Add(expressionEqualityComparer.GetHashCode(order.KeySelector));

        hashCode.Add(PaginationOptions);

        return hashCode.ToHashCode();
    }

    ///<summary>
    /// Checks equality with another object based on hash codes.
    ///</summary>
    public override bool Equals(object? obj)
    {
        return obj is QuerySpecification<TSource> querySpecification && querySpecification.GetHashCode() == GetHashCode();
    }
}

///<summary>
/// Represents a non-generic query specification for filtering, ordering, and pagination.
/// Implements the ICacheModel interface.
///</summary>
public class QuerySpecification : ICacheModel
{
    ///<summary>
    /// Gets the pagination options specified for the query.
    ///</summary>
    public FilterPagination PaginationOptions { get; set; }

    ///<summary>
    /// Gets a flag indicating whether to use no-tracking for the query.
    ///</summary>
    public bool AsNoTracking { get; }

    ///<summary>
    /// Constructor with parameters to set page size, page token, and no-tracking option.
    ///</summary>
    ///<param name="pageSize">The size of each page in the result set.</param>
    ///<param name="pageToken">The token representing the current page.</param>
    ///<param name="asNoTracking">Flag indicating whether to use no-tracking for the query.</param>
    public QuerySpecification(uint pageSize, uint pageToken, bool asNoTracking)
    {
        PaginationOptions = new FilterPagination(pageSize, pageToken);
        AsNoTracking = asNoTracking;
    }

    ///<summary>
    /// Constructor with parameters to set pagination options and no-tracking option.
    ///</summary>
    ///<param name="filterPagination">The pagination options for the query.</param>
    ///<param name="asNoTracking">Flag indicating whether to use no-tracking for the query.</param>
    public QuerySpecification(FilterPagination filterPagination, bool asNoTracking)
    {
        PaginationOptions = filterPagination;
        AsNoTracking = asNoTracking;
    }

    ///<summary>
    /// Calculates the hash code based on pagination options.
    ///</summary>
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(PaginationOptions);
        return hashCode.ToHashCode();
    }

    ///<summary>
    /// Checks equality with another object based on hash codes.
    ///</summary>
    public override bool Equals(object? obj)
    {
        return obj is QuerySpecification querySpecification && querySpecification.GetHashCode() == GetHashCode();
    }

    ///<summary>
    /// Gets the cache key for the query specification.
    ///</summary>
    public string CacheKey => GetHashCode().ToString();
}
