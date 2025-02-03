using Microsoft.AspNetCore.Mvc;
using Movies.Common.Notification.Interfcaes;
using Movies.Core.Requests.Users;
using Movies.Services.Services.User.Interfaces;

namespace Moovies.Controllers
{
    public class UsersController(
        IUserService _userService,
        INotificationContext _notificationContext
    ) : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            var request = new UserCreateRequest();
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _userService.CreateAsync(request);
            if (!result)
            {
                var notifications = _notificationContext.Notifications.Select(n => new
                {
                    type = n.Type.ToString().ToLower(),
                    title = n.Title,
                    message = n.Message
                });
                return BadRequest(new { errors = notifications });
            }

            return RedirectToAction("Home","Index");
        }
    }
}
