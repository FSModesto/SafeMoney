using Domain.Entities;
using Domain.Interfaces;
using Infra.Contexts;

namespace Infra.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly SafeMoneyContext _context;

        public UserRepository(SafeMoneyContext context) : base(context)
        {
            _context = context;
        }
    }
}
