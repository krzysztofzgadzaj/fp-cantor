using System.Threading;
using System.Threading.Tasks;
using MediatR;
using User.Application.Contracts.Queries.Base;
using User.Application.Handlers.Queries.Base;

namespace User.Infrastructure.Messaging.Queries
{
    public sealed class QueryBus : Bus,
        IQueryBus
    {
        public QueryBus(IMediator mediator)
            : base(mediator)
        {
        }

        public async Task<TResponse> QueryAsync<TResponse>(IQuery<TResponse> query,
            CancellationToken cancellationToken = default) =>
            await Mediator.Send(query,
                cancellationToken);
    }
}