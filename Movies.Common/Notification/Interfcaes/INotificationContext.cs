namespace Movies.Common.Notification.Interfcaes;

using System.Collections.Generic;

public interface INotificationContext
{
    IReadOnlyCollection<NotificationMessage> Notifications { get; }
    void AddNotification(string title, string message, NotificationType type);
    void AddNotifications(IEnumerable<NotificationMessage> notifications);
    bool HasNotifications();
}

