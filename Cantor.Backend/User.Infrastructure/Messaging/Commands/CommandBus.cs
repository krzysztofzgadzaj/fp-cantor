using System.Threading;
using System.Threading.Tasks;
using MediatR;
using User.Application.Contracts.Commands.Base;
using User.Application.Handlers.Commands.Base;

namespace User.Infrastructure.Messaging.Commands
{
    public sealed class CommandBus : Bus,
        ICommandBus
    {
        public CommandBus(IMediator mediator)
            : base(mediator)
        {
        }

        public async Task SendAsync(ICommand command, CancellationToken cancellationToken) =>
            await Mediator
                .Send(command, cancellationToken);
    }
}