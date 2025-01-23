using Movies.Core.Requests.Users;

namespace Movies.Services.Services.User;

public interface IUserService
{
    Task<bool> CreateAsync(UserCreateRequest request);
}
