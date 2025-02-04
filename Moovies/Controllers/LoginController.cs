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

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
            });
        }

        var result = await _loginService.LoginAsync(request);

        if (result is null)
        {
            var notifications = _notificationContext.Notifications.Select(n => new
            {
                type = n.Type.ToString().ToLower(),
                title = n.Title,
                message = n.Message
            });
            return BadRequest(new { errors = notifications });
        }

        return Ok(new { token = result.Token }); 
    }
}

