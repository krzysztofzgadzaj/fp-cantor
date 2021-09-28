using System;
using System.Threading.Tasks;
using Cantor.Application.Contracts.Commands;
using Cantor.Application.Contracts.Queries;
using Cantor.Application.Dto;
using Cantor.Application.Entities;
using Cantor.Application.Handlers.Commands.Base;
using Cantor.Application.Handlers.Queries.Base;
using Cantor.Infrastructure.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Cantor.Infrastructure.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    public class CantorController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public CantorController(ICommandBus commandBus,
            IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
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

        [HttpGet("{userId:guid}/balance")]
        public async Task<ActionResult<InvestmentPortfolioDto>> GetInvestmentPortfolio(
            [FromRoute] Guid userId)
        {
            var query = new GetInvestmentPortfolioQuery(userId);
            var response = await _queryBus.QueryAsync(query);

            return Ok(response);
        }
    }
}