using System;
using Cantor.Application.Contracts.Queries.Base;
using Cantor.Application.Dto;

namespace Cantor.Application.Contracts.Queries
{
    public sealed record GetInvestmentPortfolioQuery(
        Guid UserId) : IQuery<InvestmentPortfolioDto>;
}