using Airbnb.Domain.Common.Entities;
using AirBnB.Domain.Common.Query;

namespace Airbnb.Domain.Common.Query.Interfaces;
///<summary>
/// Defines an interface for objects that can be converted to a query specification for entities of type TEntity.
///</summary>
///<typeparam name="TEntity">The type of entity for which the query specification is generated.</typeparam>
public interface IQueryConvertible<TEntity> where TEntity : Entity
{
    ///<summary>
    /// Converts the object to a query specification for entities of type TEntity.
    ///</summary>
    ///<returns>A QuerySpecification for entities of type TEntity.</returns>
    QuerySpecification<TEntity> ToQuerySpecification();
}

///<summary>
/// Defines an interface for objects that can be converted to a generic query specification.
///</summary>
public interface IQueryConvertible
{
    ///<summary>
    /// Converts the object to a generic query specification.
    ///</summary>
    ///<returns>A generic QuerySpecification.</returns>
    QuerySpecification ToQuerySpecification();
}
