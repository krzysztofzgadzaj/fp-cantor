using Cantor.Application.Contracts.Queries.Base;
using MediatR;

namespace Cantor.Application.Handlers.Queries.Base
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}