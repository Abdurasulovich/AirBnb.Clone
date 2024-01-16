using Airbnb.Domain.Common.Entities;
using AirBnB.Domain.Common.Query;
using Airbnb.Domain.Common.Query.Interfaces;

namespace Airbnb.Domain.Common.Query;

///<summary>
/// Represents filter and pagination parameters for querying data.
///</summary>
public class FilterPagination
{
    ///<summary>
    /// Gets or sets the page size for the result set.
    ///</summary>
    public uint PageSize { get; init; } = 10;

    ///<summary>
    /// Gets or sets the page token for pagination.
    ///</summary>
    public uint PageToken { get; init; } = 1;

    ///<summary>
    /// Constructor with parameters to set page size and page token.
    ///</summary>
    ///<param name="pageSize">The size of each page in the result set.</param>
    ///<param name="pageToken">The token representing the current page.</param>
    public FilterPagination(uint pageSize, uint pageToken)
    {
        PageSize = pageSize;
        PageToken = pageToken;
    }

    ///<summary>
    /// Default constructor.
    ///</summary>
    public FilterPagination()
    {
    }

    ///<summary>
    /// Calculates the hash code based on page size and page token.
    ///</summary>
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageSize);
        hashCode.Add(PageToken);

        return hashCode.ToHashCode();
    }

    ///<summary>
    /// Checks equality with another object based on hash codes.
    ///</summary>
    public override bool Equals(object? obj)
    {
        return obj is FilterPagination filterPagination && filterPagination.GetHashCode() == GetHashCode();
    }
}
