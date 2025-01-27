namespace Movies.Common.Notification.Interfcaes;

public interface INotificationContext
{
    void AddNotification(string message, string type);
    void AddNotifications(IEnumerable<NotificationMessage> notifications);
}
