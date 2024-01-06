using Airbnb.Api.Models.Dtos;
using Airbnb.Application.Common.Services.Interfaces;
using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using Airbnb.Infrastructure.Settings;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Airbnb.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LocationCategoryController(
    ILocationCategoryService _locationCategoryService,
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> GetAsync(
        [FromQuery]FilterPagination paginationOptions,
        CancellationToken cancellationToken = default
    )
    {
        var specification = paginationOptions.ToQueryPagination(true).ToQuerySpecification();
        var result = await _locationCategoryService.GetAsync(specification, cancellationToken);

        return result.Any() ? Ok(mapper.Map<List<LocationCategoryDto>>(result)) : NoContent();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(
        [FromBody] LocationCategoryDto locationCategoryDto,
        CancellationToken cancellationToken = default)
    {

        var result = await _locationCategoryService.CreateAsync(mapper.Map<LocationCategory>(locationCategoryDto),
            cancellationToken: cancellationToken);

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromBody] LocationCategoryDto locationCategoryDto,
        CancellationToken cancellationToken = default)
    {
        var result = await _locationCategoryService.UpdateAsync(mapper.Map<LocationCategory>(locationCategoryDto));

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteByIdAsync([FromQuery] Guid id,
        CancellationToken cancellationToken = default)
    {
        var result = await _locationCategoryService.DeleteByIdAsync(id, cancellationToken: cancellationToken);

        return result ? Ok(result) : BadRequest();
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
            await _locationCategoryService.UploadImgAsync(id, imagePath, environment.WebRootPath, cancellationToken);

        return result is not null ? Ok(result) : BadRequest();
    }
}
