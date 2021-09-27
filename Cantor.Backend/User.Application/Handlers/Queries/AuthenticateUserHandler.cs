using System.Threading;
using System.Threading.Tasks;
using User.Application.Contracts.Queries;
using User.Application.Dto;
using User.Application.Handlers.Queries.Base;
using User.Application.Repositories;
using User.Application.Services;

namespace User.Application.Handlers.Queries
{
    public sealed class AuthenticateUserHandler : IQueryHandler<AuthenticateUserQuery, AuthenticationResultDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthenticateUserHandler(
            IUserRepository userRepository,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        
        public async Task<AuthenticationResultDto> Handle(AuthenticateUserQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByLogin(query.Login);
            var doesExist = user is not null;
            
            //var isAuthenticated = doesExist && _encryptionService.VerifyPassword(user.Password, query.Password);

            var isAuthenticated = doesExist && System.Text.Encoding.Default.GetString(user.Password) == query.Password;
            
            var authenticationResult = isAuthenticated
                ? new AuthenticationResultDto(
                    true,
                    _tokenService.GenerateToken(user.Id),
                    (UserDto) user)
                : new AuthenticationResultDto(
                    false,
                    string.Empty,
                    default);

            return authenticationResult;
        }
    }
}