using Airbnb.Application.Common.Notifications.Events;
using Airbnb.Application.Common.Notifications.Models;
using AutoMapper;

namespace Airbnb.Infrastructure.Notifications.Mappers;

public class NotificationRequestMapper : Profile
{
    public NotificationRequestMapper()
    {
        CreateMap<ProcessNotificationEvent, EmailProcessNotificationEvent>();
    }
}