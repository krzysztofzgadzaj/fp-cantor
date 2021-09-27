using MediatR;

namespace User.Application.Contracts.Queries.Base
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}