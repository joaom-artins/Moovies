using Microsoft.EntityFrameworkCore;
using Movies.Core.Models;
using Movies.Data.Context;
using Movies.Data.Repositories.Generic;
using Movies.Data.Repositories.Interfaces;

namespace Movies.Data.Repositories.Repository;

public class UserRepository(AppDbContext context) : GenericRepository<UserModel>(context),
    IUserRepository
{
    private readonly AppDbContext _context = context;

    public async Task<UserModel?> GetByEmailAsync(string email)
    {
        return await _context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Email == email); 
    }

    public async Task<UserModel?> GetByUsernameAsync(string username)
    {
        return await _context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.UserName == username);
    }
}
