using Cantor.Application.Contracts.Commands.Base;
using MediatR;

namespace Cantor.Application.Handlers.Commands.Base
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
        where TCommand : ICommand
    {
    }
}