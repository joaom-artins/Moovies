using Microsoft.EntityFrameworkCore;
using Movies.Core.Models;
using Movies.Data.Context;
using Movies.Data.Repositories.Generic;
using Movies.Data.Repositories.Repository.User.Interface;

namespace Movies.Data.Repositories.Repository.User;

public class UserRepository(AppDbContext context) : GenericRepository<UserModel>(context),
    IUserRepository
{
}
