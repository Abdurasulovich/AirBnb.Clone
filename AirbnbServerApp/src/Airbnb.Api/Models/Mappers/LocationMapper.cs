using Airbnb.Api.Models.Dtos;
using Airbnb.Domain.Entities;
using AutoMapper;

namespace Airbnb.Api.Models.Mappers;

public class LocationMapper : Profile
{
    public LocationMapper()
    {
        CreateMap<Location, LocationDto>().ReverseMap();
    }
}