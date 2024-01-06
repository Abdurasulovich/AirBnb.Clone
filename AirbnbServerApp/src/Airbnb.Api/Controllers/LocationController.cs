using Airbnb.Api.Models.Dtos;
using Airbnb.Application.Common.Models;
using Airbnb.Application.Common.Services.Interfaces;
using Airbnb.Domain.Common.Query;
using Airbnb.Infrastructure.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Airbnb.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LocationController(ILocationService _locationService) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> GetAsync(
        [FromQuery]LocationFilter locationFilter,
        [FromServices] IOptions<ApiSettings> apiSettings,
        CancellationToken cancellationToken = default)
    {
        var result = await _locationService.GetAsync(locationFilter.ToQuerySpecification(), cancellationToken: cancellationToken);
        var locations = result.Select(location => new LocationDto
        {
            Id = location.Id,
            Name = location.Name,
            ImageUrl = location.ImageUrl,
            BuiltYear = location.BuiltYear,
            PricePerNight = location.PricePerNight,
            FeedBack = location.FeedBack,
        });

        return locations.Any() ? Ok(locations) : BadRequest();
    }

    //[HttpPost]
    //public async ValueTask<IActionResult> CreateAsync(
    //    [FromBody]LocationDto locationDto, CancellationToken cancellationToken)
    //{
        
    //}
}
