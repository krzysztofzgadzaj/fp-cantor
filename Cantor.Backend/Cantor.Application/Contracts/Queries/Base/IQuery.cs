using MediatR;

namespace Cantor.Application.Contracts.Queries.Base
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}