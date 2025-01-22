using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Movies.Common.LoggedUser;
using Movies.Common.LoggedUser.Interfaces;

namespace Movies.Common.Utils
{
    public class RegisterCommons
    {
        public static void Register(WebApplicationBuilder builder)
        {
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<ILoggedUser, LoggedUserHelper>();
        }
    }
}
