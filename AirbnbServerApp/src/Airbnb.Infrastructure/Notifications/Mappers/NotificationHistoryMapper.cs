using Airbnb.Application.Common.Notifications.Events;
using Airbnb.Application.Common.Notifications.Models;
using Airbnb.Domain.Entities;
using AutoMapper;

namespace Airbnb.Infrastructure.Notifications.Mappers;

public class NotificationHistoryMapper : Profile
{
    public NotificationHistoryMapper()
    {
        CreateMap<EmailMessage, EmailHistory>()
            .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.Template.Id))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Body));
    }
}