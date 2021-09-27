using System.Threading;
using System.Threading.Tasks;
using User.Application.Contracts.Queries.Base;

namespace User.Application.Handlers.Queries.Base
{
    public interface IQueryBus
    {
        Task<TResponse> QueryAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
    }
}