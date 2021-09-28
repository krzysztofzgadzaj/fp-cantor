using System;
using User.Application.Contracts.Commands.Base;

namespace User.Application.Contracts.Commands
{
    public sealed record CreateUserCommand(
        Guid Id,
        string Login,
        string FirstName,
        string SecondName,
        string EmailAddress,
        string Password) : ICommand;
}