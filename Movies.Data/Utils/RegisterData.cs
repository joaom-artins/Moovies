using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Data.Context;
using Movies.Data.Repositories.Repository.Comment;
using Movies.Data.Repositories.Repository.Comment.Interfaces;
using Movies.Data.Repositories.Repository.Movie;
using Movies.Data.Repositories.Repository.Movie.Interface;
using Movies.Data.Repositories.Repository.User;
using Movies.Data.Repositories.Repository.User.Interface;
using Movies.Data.UnitOfWork.Interfaces;

namespace Movies.Data.Utils
{
    public class RegisterData
    {
        public static void Register(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        );
        }
    }
}
