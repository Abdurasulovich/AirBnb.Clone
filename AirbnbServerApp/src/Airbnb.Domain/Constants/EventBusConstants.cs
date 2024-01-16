namespace Airbnb.Domain.Constants;

///<summary>
/// Constants for event bus configurations related to notifications.
///</summary>
public class EventBusConstants
{
    #region Notifications

    ///<summary>
    /// Exchange name for notifications.
    ///</summary>
    public const string NotificationExchangeName = "Notifications";

    ///<summary>
    /// Queue name for processing notifications.
    ///</summary>
    public const string ProcessNotificationQueueName = "ProcessNotification";

    ///<summary>
    /// Queue name for rendering notifications.
    ///</summary>
    public const string RenderNotificationQueueName = "RenderNotification";

    ///<summary>
    /// Queue name for sending notifications.
    ///</summary>
    public const string SendNotificationQueueName = "SendNotification";

    #endregion
}
