using MediatR;
using User.Application.Contracts.Queries.Base;

namespace User.Application.Handlers.Queries.Base
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}