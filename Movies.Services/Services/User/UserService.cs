using Microsoft.AspNetCore.Identity;
using Movies.Core.Models;
using Movies.Core.Requests.Users;
using Movies.Data.Repositories.Repository.User;

namespace Movies.Services.Services.User;

public class UserService(
    IUserRepository _userRepository,
    UserManager<UserModel> _userManager
) : IUserService
{
    public async Task<bool> CreateAsync(UserCreateRequest request)
    {
        if(request.Password != request.ConfirmPassword)
        {
            return false;
        }

        var existsEmail = await _userRepository.GetByGenericPropertyAsync("Email",request.Email);
        if (existsEmail != null)
        {
            return false;
        }

        var existsUserName = await _userRepository.GetByGenericPropertyAsync("USerName",request.UserName);
        if (existsUserName != null)
        {
            return false;
        }

        var result = await _userManager.CreateAsync(new UserModel
        { 
            Email = request.Email,
            UserName = request.UserName,
        },request.Password);

        if (!result.Succeeded)
        {
            return false;
        }

        var user = await _userManager.FindByEmailAsync(request.Email);

        var role = await _userManager.AddToRoleAsync(user!, "user");
        if(!role.Succeeded)
        {
            return false;
        }

        return true;
    }
}
