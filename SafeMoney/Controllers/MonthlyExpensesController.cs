using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SafeMoneyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MonthlyExpensesController : ControllerBase
    {
        private readonly IMonthlyExpensesHandler _handler;

        public MonthlyExpensesController(IMonthlyExpensesHandler handler)
        {
            _handler = handler;
        }
    }
}
