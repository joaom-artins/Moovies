using Movies.Common.Notification.Interfcaes;
using Movies.Common.Notification;

namespace Movies.Common.Notification;

public class NotificationContext : INotificationContext
{
    private readonly List<NotificationMessage> _notifications = [];

    public IReadOnlyCollection<NotificationMessage> Notifications => _notifications;

    public void AddNotification(string title, string message, NotificationType type)
    {
        _notifications.Add(new NotificationMessage(title, message, type));
    }

    public void AddNotifications(IEnumerable<NotificationMessage> notifications)
    {
        throw new NotImplementedException();
    }

    public bool HasNotifications() => _notifications.Count != 0;
}
