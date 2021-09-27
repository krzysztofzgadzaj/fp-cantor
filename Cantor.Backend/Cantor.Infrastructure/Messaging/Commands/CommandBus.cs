using System.Threading;
using System.Threading.Tasks;
using Cantor.Application.Contracts.Commands.Base;
using Cantor.Application.Handlers.Commands.Base;
using MediatR;

namespace Cantor.Infrastructure.Messaging.Commands
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