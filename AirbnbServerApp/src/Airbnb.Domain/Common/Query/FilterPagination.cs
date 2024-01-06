using AirBnB.Domain.Common.Query;
using Airbnb.Domain.Common.Query.Interfaces;

namespace Airbnb.Domain.Common.Query;

public class FilterPagination : IQueryConvertible
{
    public uint PageSize { get; init; } = 10;

    public uint PageToken { get; init; } = 1;

    public FilterPagination(uint pageSize, uint pageToken)
    {
        PageSize = pageSize;
        PageToken = pageToken;
    }

    public FilterPagination()
    {
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageSize);
        hashCode.Add(PageToken);

        return hashCode.ToHashCode();
    }
    public QueryPagination ToQueryPagination(bool asNoTracking) => new(PageSize, PageToken, asNoTracking);

    public virtual QuerySpecification ToQuerySpecification()
        =>  throw new NotSupportedException($"Filter pagination doesn't support converting to query specification");


    public override bool Equals(object? obj)
    {
        return obj is FilterPagination filterPagination && filterPagination.GetHashCode() == GetHashCode();
    }
}