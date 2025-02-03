using Microsoft.AspNetCore.Mvc;
using Movies.Common.Notification.Interfcaes;
using Movies.Core.Requests.Login;
using Movies.Services.Services.Login.Interfaces;

namespace Moovies.Controllers;

public class LoginController(
    INotificationContext _notificationContext,
    ILoginService _loginService
    ) : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        var request = new LoginRequest();

        return View(request);
    }

    public async Task<IActionResult> Login([FromBody]LoginRequest request)
    {
        if(!ModelState.IsValid)
        {
            return View(request);
        }

        var result = await _loginService.LoginAsync(request);
        if(result is null)
        {
            var notifications = _notificationContext.Notifications.Select(n => new
            {
                type = n.Type.ToString().ToLower(),
                title = n.Title,
                message = n.Message
            });
            return BadRequest(new { errors = notifications });
        }

        return RedirectToAction("Home", "Index");
    }
}

