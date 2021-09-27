﻿using System.Threading;
using System.Threading.Tasks;
using Cantor.Application.Contracts.Queries.Base;
using Cantor.Application.Handlers.Queries.Base;
using MediatR;

namespace Cantor.Infrastructure.Messaging.Queries
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