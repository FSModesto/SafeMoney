using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infra.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _privateKey;
        public TokenService(IConfiguration configuration)
        {
            _privateKey = configuration.GetValue<string>("SecretKey:PrivateKey");
        }
        public string CreateToken(User user, TimeSpan expiration)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_privateKey);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                algorithm: SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.Add(expiration),
                IssuedAt = DateTime.UtcNow
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        public ClaimsPrincipal ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_privateKey);

            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true
            }, out validatedToken);

            return principal;
        }
    }
}
