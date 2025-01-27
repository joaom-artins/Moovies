using Microsoft.EntityFrameworkCore;
using Movies.Core.Models;
using Movies.Data.Context;
using Movies.Data.Repositories.Generic;

namespace Movies.Data.Repositories.Repository.User;

public class UserRepository(AppDbContext context) : GenericRepository<UserModel>(context),
    IUserRepository
{
}
