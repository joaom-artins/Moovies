using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Data.Context;
using Movies.Data.Repositories.Interfaces;
using Movies.Data.Repositories.Repository;

namespace Movies.Data.Utils
{
    public class RegisterData
    {
        public static void Register(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        );
        }
    }
}
