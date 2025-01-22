using Movies.Core.Models;
using Movies.Data.Repositories.Generic.Interfaces;

namespace Movies.Data.Repositories.Interfaces;

public interface IUserRepository : IGenericRepository<UserModel>
{
    Task<UserModel?> GetByEmailAsync(string email);
    Task<UserModel?> GetByUsernameAsync(string username);
}
