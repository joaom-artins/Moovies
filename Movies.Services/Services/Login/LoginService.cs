using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Movies.Common.Notification;
using Movies.Common.Notification.Interfcaes;
using Movies.Core.Models;
using Movies.Data.Repositories.Repository.User.Interface;
using Movies.Common;
using Movies.Core.Response;
using Movies.Services.Services.Login.Interfaces;
using Movies.Core.Requests.Login;

namespace Movies.Services.Services.Login;

public class LoginService(
    INotificationContext _notificationContext,
    AppSettings _appSettings,
    UserManager<UserModel> _userManager,
    SignInManager<UserModel> _signManager,
    IUserRepository _userRepository
) : ILoginService
{
    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByGenericPropertyAsync("Email",request.EmailOrUsername);
        if(user is null)
        {
            _notificationContext.AddNotification(Titles.InvalidRequisition, Messages.User.InvalidLogin,NotificationType.Erro);

            return default!;
        }

        var result = await _signManager.CheckPasswordSignInAsync(user, request.Password,false);
        if (!result.Succeeded)
        {
            _notificationContext.AddNotification(Titles.InvalidRequisition, Messages.User.InvalidLogin, NotificationType.Erro);

            return default!;
        }

        var accessToken = await GenerateAccessTokenAsync(user);
        if (_notificationContext.HasNotifications())
        {
            return default!;
        }

        return new LoginResponse
        {
            Token = accessToken,
        };
    }

    private async Task<string> GenerateAccessTokenAsync(UserModel user)
    {
        var role = await _userManager.GetRolesAsync(user);
        if (role is null)
        {
            _notificationContext.AddNotification(Titles.InvalidRequisition, Messages.Common.ValidationError, NotificationType.Erro);
            
            return default!;
        }

        var tokenHandle = new JwtSecurityTokenHandler();

        var claims = new List<Claim>
        {
            new("userId", user!.Id.ToString()),
            new(ClaimTypes.Role, role.First()),
        };

        var key = Encoding.ASCII.GetBytes(_appSettings.Jwt.SecretKey);

        var token = tokenHandle.CreateToken(new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddSeconds(_appSettings.Jwt.Expiration),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        });

        return tokenHandle.WriteToken(token);
    }
}
