using Airbnb.Domain.Common.Entities.Interfaces;

namespace Airbnb.Domain.Common.Entities;

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
}