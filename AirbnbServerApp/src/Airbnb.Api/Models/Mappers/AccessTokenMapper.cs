using Airbnb.Api.Models.Dtos;
using Airbnb.Identity.Domain.Entities;
using AutoMapper;

namespace Airbnb.Api.Models.Mappers;

public class AccessTokenMapper : Profile
{
    public AccessTokenMapper()
    {
        CreateMap<AccessToken, AccessTokenDto>().ReverseMap();
    }
}