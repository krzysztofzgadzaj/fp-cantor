using System.Threading;
using System.Threading.Tasks;
using Cantor.Application.Contracts.Commands.Base;

namespace Cantor.Application.Handlers.Commands.Base
{
    public interface ICommandBus
    {
        Task SendAsync(ICommand command, CancellationToken cancellationToken = default);
    }
}