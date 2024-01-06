using Airbnb.Api.Models.Dtos;
using Airbnb.Domain.Entities;
using AutoMapper;

namespace Airbnb.Api.Models.Mappers;

public class LocationCategoryMapper : Profile
{
    public LocationCategoryMapper()
    {
        CreateMap<LocationCategory, LocationCategoryDto>().ReverseMap();
    }
}