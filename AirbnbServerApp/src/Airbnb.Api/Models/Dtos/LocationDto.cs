namespace Airbnb.Api.Models.Dtos;

public class LocationDto
{
    public Guid Id { get; set; } 
    
    public string ImageUrl { get; set; }

    public string Name { get; set; } = default!;
    
    public string BuiltYear { get;set; } = default!;
    
    public int PricePerNight { get; set; }

    public float FeedBack { get;set; }

    public Guid CategoryId { get; set; }

    public string FreeDate { get; set; } = default!;
}
