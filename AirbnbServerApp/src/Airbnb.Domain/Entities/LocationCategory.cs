using Airbnb.Domain.Common.Entities;

namespace Airbnb.Domain.Entities;

public class LocationCategory : Entity
{
    public string Name { get; set; } = default!;

    public string ImagePath { get; set; }

    public virtual List<Location> Locations { get; set; } = new();
}