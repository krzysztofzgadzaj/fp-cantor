using System.Threading.Tasks;
using Cantor.Application.Contracts.Commands;
using Cantor.Application.Entities;
using Cantor.Application.Handlers.Commands.Base;
using Microsoft.AspNetCore.Mvc;

namespace Cantor.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CantorController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public CantorController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateInvestmentPortfolio([FromBody] CreateInvestmentPortfolioCommand command)
        {
            await _commandBus.SendAsync(command);
            
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<InvestmentPortfolio>> UpdateInvestmentPortfolio(
            [FromBody] UpdateInvestmentPortfolioCommand command)
        {
            await _commandBus.SendAsync(command);

            return Ok();
        }
    }
}