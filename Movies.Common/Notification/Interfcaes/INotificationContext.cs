namespace Movies.Common.Notification.Interfcaes;

public interface INotificationContext
{
    void AddNotification(string title, string message);
    void AddNotifications(IEnumerable<NotificationMessage> notifications);
}
