using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Movies.Core.Models;
using Movies.Data.Context;
using Movies.Services.Services.Login.Interfaces;
using Movies.Services.Services.User;
using Movies.Services.Services.User.Interfaces;
using Movies.Services.Services.Login;
using Microsoft.Extensions.Options;
using Movies.Common;

namespace Movies.Services.Utils;

public class RegisterServices
{
    public static void Register(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<ILoginService, LoginService>();

        var appSettings = builder.Configuration.GetSection("AppSettings");
        builder.Services.Configure<AppSettings>(appSettings);
        builder.Services.AddSingleton(serviceProvider => serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value);
    }
}
