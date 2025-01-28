using Microsoft.AspNetCore.Mvc;
using Movies.Core.Requests.Users;
using Movies.Services.Services.User.Interfaces;

namespace Moovies.Controllers
{
    public class UsersController(
        IUserService _userService
    ) : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            var request = new UserCreateRequest();
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _userService.CreateAsync(request);

            return RedirectToAction("Index", "Home");
        }
    }
}
