using Microsoft.AspNetCore.Mvc.Filters;
using Movies.Common.Notification.Interfcaes;
using Microsoft.AspNetCore.Mvc; 


namespace Moovies.Utils.Filters;

public class NotificationActionFilter : IAsyncActionFilter
{
    private readonly INotificationContext _notificationContext;

    public NotificationActionFilter(INotificationContext notificationContext) => _notificationContext = notificationContext;

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var resultContext = await next();

        if (_notificationContext.HasNotifications())
        {
            if (context.Controller is Controller controller)
            {
                controller.ViewData["Notifications"] = _notificationContext.Notifications;
            }
        }
    }
}
