using Airbnb.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirBnB.Domain.Common.Query;

namespace Airbnb.Domain.Common.Query.Interfaces;

public interface IQueryConvertible<TEntity> where TEntity : Entity
{
    QuerySpecification<TEntity> ToQuerySpecification();
}
public interface IQueryConvertible
{
    QuerySpecification ToQuerySpecification();
}