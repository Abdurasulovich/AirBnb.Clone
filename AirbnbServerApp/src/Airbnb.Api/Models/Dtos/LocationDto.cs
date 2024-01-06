namespace Airbnb.Api.Models.Dtos;

public class LocationDto
{
    public Guid Id { get; set; }

    public string ImageUrl { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string BuiltYear { get; set; }

    public int PricePerNight { get; set; }

    public float FeedBack { get; set; }
}
