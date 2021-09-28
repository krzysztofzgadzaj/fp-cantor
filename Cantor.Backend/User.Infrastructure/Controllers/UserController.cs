using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.Application.Contracts.Commands;
using User.Application.Handlers.Commands.Base;
using User.Infrastructure.Controllers.Base;

namespace User.Infrastructure.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    public sealed class UserController : BaseController
    {
        private const string ControllerName = "User";
        private readonly ICommandBus _commandBus;

        public UserController(
            ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand command,
            CancellationToken cancellationToken)
        {
            command = command with { Id = Guid.NewGuid() };
            
            await _commandBus.SendAsync(command, cancellationToken);

            var uri = GetUri(command.Id, ControllerName);
            var resultAction = Created(uri, command.Id);

            return resultAction;
        }
    }
}