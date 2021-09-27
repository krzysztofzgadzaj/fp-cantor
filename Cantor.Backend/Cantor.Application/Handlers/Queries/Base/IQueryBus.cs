using System.Threading;
using System.Threading.Tasks;
using Cantor.Application.Contracts.Queries.Base;

namespace Cantor.Application.Handlers.Queries.Base
{
    public interface IQueryBus
    {
        Task<TResponse> QueryAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
    }
}