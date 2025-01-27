namespace Movies.Common.Notification;

public class NotificationMessage(string title, string message)
{
    public string Title { get; private set; } = title;
    public string Message { get; private set; } = message;
}
