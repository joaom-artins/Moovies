using Microsoft.AspNetCore.Identity;
using Movies.Core.Models;
using Movies.Core.Requests.Users;
using Movies.Services.Services.User.Interfaces;
using Movies.Common.Notification.Interfcaes;
using Movies.Common.Notification;
using Movies.Data.Repositories.Generic.Interfaces;
using Movies.Data.Repositories.Repository.User.Interface;

namespace Movies.Services.Services.User;

public class UserService(
    IUserRepository _userRepository,
    UserManager<UserModel> _userManager,
    INotificationContext _notificationContext
) : IUserService
{
    public async Task<bool> CreateAsync(UserCreateRequest request)
    {
        if(request.Password != request.ConfirmPassword)
        {
            _notificationContext.AddNotification(Titles.InvalidRequisition, Messages.User.PasswordAreDifferents);
            return false;
        }

        var existsEmail = await _userRepository.GetByGenericPropertyAsync("Email",request.Email);
        if (existsEmail != null)
        {
            _notificationContext.AddNotification(Titles.Conflict,Messages.User.EmailExists);

            return false;
        }

        var existsUserName = await _userRepository.GetByGenericPropertyAsync("UserName",request.UserName);
        if (existsUserName != null)
        {
            _notificationContext.AddNotification(Titles.Conflict, Messages.User.UsernameExists);

            return false;
        }

        var result = await _userManager.CreateAsync(new UserModel
        { 
            Email = request.Email,
            UserName = request.UserName,
        },request.Password);

        if (!result.Succeeded)
        {
            _notificationContext.AddNotification(Titles.InvalidRequisition, Messages.User.ErrorInCreate);

            return false;
        }

        var user = await _userManager.FindByEmailAsync(request.Email);

        var role = await _userManager.AddToRoleAsync(user!, "user");
        if(!role.Succeeded)
        { 
            _notificationContext.AddNotification(Titles.InvalidRequisition, Messages.User.ErrorInCreate);

            return false;
        }

        return true;
    }
}
