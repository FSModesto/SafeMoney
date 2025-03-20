using Domain.Entities;
using Domain.Interfaces;
using Infra.Contexts;

namespace Infra.Repository
{
    public class ExpensesRepository : BaseRepository<Expenses>, IExpensesRepository
    {
        private readonly SafeMoneyContext _context;

        public ExpensesRepository(SafeMoneyContext context) : base(context)
        {
            _context = context;
        }
    }
}