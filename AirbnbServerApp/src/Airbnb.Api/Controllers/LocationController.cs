using Airbnb.Api.Models.Dtos;
using Airbnb.Application.Common.Services.Interfaces;
using Airbnb.Domain.Common.Query;
using AirBnB.Domain.Common.Query;
using Airbnb.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LocationController(ILocationService _locationService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get(
        [FromQuery] FilterPagination paginationOptions, 
        CancellationToken cancellationToken = default)
    {
        var result =  _locationService.Get();
        
        return result.Any() ? Ok(mapper.Map<List<LocationDto>>(result)) : NoContent();
    }

    [HttpGet("{locationId:guid}")]
    public async ValueTask<IActionResult> GetByIdAsync([FromRoute] Guid locationId,
        CancellationToken cancellationToken = default)
    {
        var result = await _locationService.GetByIdAsync(locationId, true, cancellationToken);

        return result is not null ? Ok(mapper.Map<LocationDto>(result)) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromBody] LocationDto locationDto,
        CancellationToken cancellationToken)
    {
        var location = mapper.Map<Location>(locationDto);
        var result = await _locationService.CreateAsync(location, true, cancellationToken);

        return Ok(mapper.Map<LocationDto>(result));
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromBody] LocationDto locationDto,
        CancellationToken cancellationToken = default)
    {
        var location = mapper.Map<Location>(locationDto);
        var result = await _locationService.UpdateAsync(location, cancellationToken: cancellationToken);

        return result is not null ? Ok(mapper.Map<LocationDto>(result)) : BadRequest();
    }

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync([FromRoute] Guid locationId, CancellationToken cancellationToken)
    {
        var location = await _locationService.DeleteByIdAsync(locationId, true, cancellationToken);
        return location ? Ok(mapper.Map<LocationDto>(location)) : NotFound();
    }
    
    [HttpPut("{id:guid}")]
    public async ValueTask<IActionResult> UploadImage(
        [FromRoute] Guid id,
        [FromServices] IWebHostEnvironment environment,
        IFormFile imagePath,
        CancellationToken cancellationToken = default
    )
    {
        var result =
            await _locationService.UploadImgAsync(id, imagePath, environment.WebRootPath, cancellationToken);

        return result is not null ? Ok(result) : BadRequest();
    }
}
