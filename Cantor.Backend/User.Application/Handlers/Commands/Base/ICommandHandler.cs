using MediatR;
using User.Application.Contracts.Commands.Base;

namespace User.Application.Handlers.Commands.Base
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
        where TCommand : ICommand
    {
    }
}