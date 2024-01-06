using Airbnb.Domain.Common.Entities;

namespace Airbnb.Domain.Entities;

public class Location : Entity
{
    public string ImageUrl { get; set; }

    public string Name { get; set; } = default!;
    
    public string BuiltYear { get;set; } = default!;
    
    public int PricePerNight { get; set; }

    public float FeedBack { get;set; }

    public Guid CategoryId { get; set; }

    public virtual LocationCategory? Category { get; set; }
    
    public string FreeDate { get; set; } = default!;
}
