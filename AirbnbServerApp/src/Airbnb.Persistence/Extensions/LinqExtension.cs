using Airbnb.Domain.Common.Entities.Interfaces;
using Airbnb.Domain.Common.Query;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Persistence.Extensions;

public static class LinqExtension
{
    public static IQueryable<TSource> ApplySpecification<TSource>(this IQueryable<TSource> source,
        QuerySpecification<TSource> querySpecification) where TSource : class, IEntity
    {
        source = source
            .ApplyPredicates(querySpecification)
            .ApplyIncludes(querySpecification)
            .ApplyPagination(querySpecification);

        return source;
    }

    public static IEnumerable<TSource> ApplySpecification<TSource>(this IEnumerable<TSource> sources,
        QuerySpecification<TSource> querySpecification) where TSource: class, IEntity
    {
        sources = sources.ApplyPredicates(querySpecification)
            .ApplyOrdering(querySpecification)
            .ApplyPagination(querySpecification);

        return sources;
    }

    public static IQueryable<TSource> ApplyPredicates<TSource>(this IQueryable<TSource> source,
        QuerySpecification<TSource> querySpecification) where TSource : IEntity
    {
        querySpecification.FilteringOptions.ForEach(predicate => source = source.Where(predicate));

        return source;
    }

    public static IQueryable<TSource> ApplyIncludes<TSource>(this IQueryable<TSource> source,
        QuerySpecification<TSource> querySpecification) where TSource : class, IEntity
    {
        querySpecification.IncludeOptions.ForEach(includeOption => source = source.Include(includeOption));

        return source; 
    }

    public static IEnumerable<TSource> ApplyPredicates<TSource>(this IEnumerable<TSource> sources,
        QuerySpecification<TSource> querySpecification) where TSource : IEntity
    {
        querySpecification.FilteringOptions.ForEach(predicate => sources = sources.Where(predicate.Compile()));

        return sources;
    }

    public static IQueryable<TSource> ApplyOrdering<TSource>(this IQueryable<TSource> source,
        QuerySpecification<TSource> querySpecification) where TSource : IEntity
    {
        if (!querySpecification.OrderingOptions.Any())
            source.OrderBy(entity => entity.Id);

        querySpecification.OrderingOptions.ForEach(orderByExpression=> source= orderByExpression.isAscending 
        ? source.OrderBy(orderByExpression.Item1)
        : source.OrderByDescending(orderByExpression.Item1));

        return source;
    }

    public static IEnumerable<TSource> ApplyOrdering<TSource>(this IEnumerable<TSource> source,
        QuerySpecification<TSource> querySpecification) where TSource: IEntity
    {
        if(!querySpecification.OrderingOptions.Any())
            source.OrderBy(entity => entity.Id);

        querySpecification.OrderingOptions.ForEach(
            orderByExpression => source = orderByExpression.isAscending
            ? source.OrderBy(orderByExpression.Item1.Compile())
            : source.OrderByDescending(orderByExpression.Item1.Compile()));

        return source;
    }

    public static IQueryable<TSource> ApplyPagination<TSource>(this IQueryable<TSource> source,
        QuerySpecification<TSource> querySpecification) where TSource : IEntity
    {
        return source.Skip((int)((querySpecification.PaginationOptions.PageToken - 1) * querySpecification.PaginationOptions.PageSize))
            .Take((int)querySpecification.PaginationOptions.PageSize);
    }

    public static IEnumerable<TSource> ApplyPagination<TSource>(this IEnumerable<TSource> source,
        QuerySpecification<TSource> querySpecification) where TSource : IEntity
    {
        return source.Skip((int)((querySpecification.PaginationOptions.PageToken-1) * querySpecification.PaginationOptions.PageSize))
            .Take((int)querySpecification.PaginationOptions.PageSize);
    }
}