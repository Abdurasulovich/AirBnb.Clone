using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Common.Query.Interfaces;
using Airbnb.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Airbnb.Application.Common.Models;

public class LocationFilter : FilterPagination, IQueryConvertible<Location>
{
    public Guid? CategoryId { get; set; }

    public string? Category { get; set; }

    public QuerySpecification<Location> ToQuerySpecification()
    {
        var querySpecification = new QuerySpecification<Location>(PageSize, PageSize, GetHashCode());
        if(Category is not null)
        {
            querySpecification.IncludeOptions.Add(location => location.Category!);
            querySpecification.FilteringOptions.Add(location => location.Category!.Name.Equals(Category));
        }

        if (CategoryId is not null)
            querySpecification.FilteringOptions.Add(location => location.Category.Id == CategoryId);

        querySpecification.PaginationOptions = this;

        return querySpecification;
    }
    public override bool Equals(object? obj)
    {
        return obj is LocationFilter locationFilter && locationFilter.GetHashCode().Equals(GetHashCode());
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageSize);
        hashCode.Add(PageToken);

        if (CategoryId.HasValue)
            hashCode.Add(CategoryId.Value);

        return hashCode.ToHashCode();
    }


}