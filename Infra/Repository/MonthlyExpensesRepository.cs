using Domain.Entities;
using Domain.Interfaces;
using Infra.Contexts;

namespace Infra.Repository
{
    public class MonthlyExpensesRepository : BaseRepository<MonthlyExpenses>, IMonthlyExpensesRepository
    {
        private readonly SafeMoneyContext _context;

        public MonthlyExpensesRepository(SafeMoneyContext context) : base(context)
        {
            _context = context;
        }
    }
}
