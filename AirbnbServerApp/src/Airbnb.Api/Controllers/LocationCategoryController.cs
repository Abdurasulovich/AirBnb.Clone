using Airbnb.Api.Models.Dtos;
using Airbnb.Application.Common.Services.Interfaces;
using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Entities;
using Airbnb.Infrastructure.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Airbnb.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LocationCategoryController(ILocationCategoryService _locationCategoryService) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> GetAsync(
        [FromQuery]FilterPagination paginationOptions,
        [FromServices]IOptions<ApiSettings> apiSettings,
        CancellationToken cancellationToken = default
    )
    {
        var querySpecification =
            new QuerySpecification<LocationCategory>(paginationOptions.PageSize, paginationOptions.PageToken);

        var result = await _locationCategoryService.GetAsync(querySpecification, cancellationToken: cancellationToken);
        var locationCategories = result.Select(locationCategory => new LocationCategoryDto
        {
            Id = locationCategory.Id,
            Name = locationCategory.Name,
            ImagePath = locationCategory.ImagePath
        });
        return locationCategories.Any() ? Ok(locationCategories) : BadRequest();
    }
}
