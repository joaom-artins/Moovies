namespace Movies.Common.Notification;

public class NotificationMessage(string title, string message, NotificationType type)
{
    public string Title { get; set; } = title;
    public string Message { get; set; } = message;
    public NotificationType Type { get; set; } = type;
}