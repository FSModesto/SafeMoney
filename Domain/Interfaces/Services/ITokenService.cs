using Domain.Entities;
using System.Security.Claims;

namespace Domain.Interfaces.Services
{
    public interface ITokenService
    {
        string CreateToken(User user, TimeSpan expiration);
        ClaimsPrincipal ValidateToken(string token);
    }
}
