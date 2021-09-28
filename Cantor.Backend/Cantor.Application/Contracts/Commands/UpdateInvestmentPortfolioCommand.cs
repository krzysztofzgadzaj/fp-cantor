using System;
using Cantor.Application.Contracts.Commands.Base;

namespace Cantor.Application.Contracts.Commands
{
    public sealed record UpdateInvestmentPortfolioCommand(
        Guid UserId,
        int GbpAmount,
        int EurAmount,
        int UsdAmount,
        int CzkAmount,
        int ChfAmount,
        int RubAmount,
        int PlnAmount) : ICommand;
}