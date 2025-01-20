using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Movies.Common.LoggedUser.Interfaces;
using Movies.Core.Models;

namespace Movies.Common.LoggedUser
{
    public class LoggedUser(
        IHttpContextAccessor _httpContextAccesor
    ) : ILoggedUser
    {
        public Guid GetId()
        {
            return Guid.Parse(_httpContextAccesor.HttpContext?.User.FindFirstValue("userId")!);
        }

        public string GetRole()
        {
            return _httpContextAccesor.HttpContext?.User.FindFirstValue(ClaimTypes.Role)!;
        }
    }
}
