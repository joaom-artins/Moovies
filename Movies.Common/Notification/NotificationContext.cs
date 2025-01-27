using Movies.Common.Notification.Interfcaes;

namespace Movies.Common.Notification;

public class NotificationContext : INotificationContext
{

    private readonly List<NotificationMessage> _notifications = [];

    public IReadOnlyCollection<NotificationMessage> Notifications => _notifications;

    public bool HasNotifications => _notifications.Count > 0;

    public void AddNotification(string message, string type)
    {
        _notifications.Add(new NotificationMessage(message, type));
    }

    public void AddNotifications(IEnumerable<NotificationMessage> notifications)
    {
        _notifications.AddRange(notifications);
    }
}
