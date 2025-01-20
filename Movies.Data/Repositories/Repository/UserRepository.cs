using Movies.Core.Models;
using Movies.Data.Context;
using Movies.Data.Repositories.Generic;
using Movies.Data.Repositories.Interfaces;

namespace Movies.Data.Repositories.Repository;

public class UserRepository(AppDbContext context) : GenericRepository<UserModel>(context),
    IUserRepository
{
}
