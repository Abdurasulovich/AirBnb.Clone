using Airbnb.Application.Common.Notifications.Models;
using AutoMapper;

namespace Airbnb.Infrastructure.Notifications.Mappers;

public class NotificationMessageMapper : Profile
{
    public NotificationMessageMapper()
    {
        CreateMap<EmailProcessNotificationEvent, EmailMessage>();
    }
}