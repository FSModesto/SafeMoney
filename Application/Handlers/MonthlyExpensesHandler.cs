using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Handlers
{
    public class MonthlyExpensesHandler : BaseHandler, IMonthlyExpensesHandler
    {
        private readonly IMapper _mapper;
        private readonly IMonthlyExpensesRepository _repository;

        public MonthlyExpensesHandler(
            IMonthlyExpensesRepository repository,
            IMapper mapper,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
