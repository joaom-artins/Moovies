using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Data.Context;

namespace Movies.Data.Repositories.Utils
{
    public  class RegisterData
    {
        public static void Register(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        );
        }
    }
}
