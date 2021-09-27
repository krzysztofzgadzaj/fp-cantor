using System.Threading;
using System.Threading.Tasks;
using User.Application.Contracts.Commands.Base;

namespace User.Application.Handlers.Commands.Base
{
    public interface ICommandBus
    {
        Task SendAsync(ICommand command, CancellationToken cancellationToken = default);
    }
}