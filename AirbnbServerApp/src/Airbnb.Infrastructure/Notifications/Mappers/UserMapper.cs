using Airbnb.Application.Common.Identity.Models;
using Airbnb.Domain.Entities;
using AutoMapper;

namespace Airbnb.Infrastructure.Notifications.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<SignUpDetails, User>();
    }
}