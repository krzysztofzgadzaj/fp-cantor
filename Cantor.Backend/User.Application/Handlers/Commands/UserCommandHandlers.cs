using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using User.Application.Contracts.Commands;
using User.Application.Entities;
using User.Application.Handlers.Commands.Base;
using User.Application.Repositories;

namespace User.Application.Handlers.Commands
{
    public sealed class UserCommandHandlers : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UserCommandHandlers(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordAsBytes = Encoding.ASCII.GetBytes(request.Password);

            var user = new CantorUser(
                request.Login, 
                request.FirstName, 
                request.SecondName, 
                request.EmailAddress,
                passwordAsBytes);

            _userRepository.Create(user);

            return null;
        }
    }
}