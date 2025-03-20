using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Handlers
{
    public class ExpensesHandler : BaseHandler, IExpensesHandler
    {
        private readonly IMapper _mapper;
        private readonly IExpensesRepository _repository;

        public ExpensesHandler(
            IExpensesRepository repository,
            IMapper mapper,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
}
