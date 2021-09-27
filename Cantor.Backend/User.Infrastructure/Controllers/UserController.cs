using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.Application.Contracts.Commands;
using User.Application.Contracts.Queries;
using User.Application.Dto;
using User.Application.Handlers.Commands.Base;
using User.Application.Handlers.Queries.Base;

namespace User.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class UserController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public UserController(
            ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }
        
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] CreateUserCommand command,
            CancellationToken cancellationToken)
        {
            await _commandBus.SendAsync(command, cancellationToken);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> Temp()
        {
            return Ok();
        }
    }
}