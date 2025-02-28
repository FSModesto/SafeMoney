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
        
    }
}
