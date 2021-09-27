using User.Application.Contracts.Queries.Base;
using User.Application.Dto;

namespace User.Application.Contracts.Queries
{
    public sealed record AuthenticateUserQuery(
        string Login,
        string Password) : IQuery<AuthenticationResultDto>;
}