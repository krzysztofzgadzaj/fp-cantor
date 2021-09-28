using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.Application.Contracts.Queries;
using User.Application.Dto;
using User.Application.Handlers.Queries.Base;
using User.Infrastructure.Controllers.Base;

namespace User.Infrastructure.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    public class AuthenticationController : BaseController
    {
        private readonly IQueryBus _queryBus;
        
        public AuthenticationController(IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }
        
        [HttpPost]
        public async Task<ActionResult<AuthenticationResultDto>> Authenticate([FromBody] AuthenticateUserQuery command)
        {
            var authenticationResult = await _queryBus.QueryAsync(command);

            return authenticationResult.IsAuthenticated
                ? Ok(authenticationResult)
                : Unauthorized(authenticationResult);
        }
    }
}