using Airbnb.Domain.Common.Query;
using Airbnb.Domain.Enums;

namespace Airbnb.Application.Common.Notifications.Models;
///<summary>
/// Represents the filter criteria for querying notification templates, including template types and pagination options.
///</summary>
public class NotificationTemplateFilter : FilterPagination
{
    ///<summary>
    /// Gets or sets the list of notification types to filter templates by.
    ///</summary>
    public IList<NotificationType> TemplateType { get; set; }
}
