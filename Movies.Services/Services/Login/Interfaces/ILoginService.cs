using Movies.Core.Requests.Login;
using Movies.Core.Response;

namespace Movies.Services.Services.Login.Interfaces;

public interface ILoginService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
}
