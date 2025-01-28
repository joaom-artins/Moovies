using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Movies.Core.Models;
using Movies.Data.Context;
using Movies.Services.Services.User;
using Movies.Services.Services.User.Interfaces;

namespace Movies.Services.Utils;

public class RegisterServices
{
    public static void Register(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserService, UserService>();
    }
}
