using Domain.Entities;
using Domain.Interfaces;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly SafeMoneyContext _context;

        public UserRepository(SafeMoneyContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetByEmailAndPassword(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<bool> VerifyPasswordAsync(string password, byte[] storedHash, byte[] storedSalt)
        {
            return await Task.Run(() =>
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
                {
                    var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    return computedHash.SequenceEqual(storedHash);
                }
            });
        }
    }
}
