using System;
using Cantor.Application.Entities;

namespace Cantor.Application.Dto
{
    public class InvestmentPortfolioDto
    {
        public Guid UserId { get; set; }
        public int GbpAmount { get; set; }
        public int EurAmount { get; set; }
        public int UsdAmount { get; set; }
        public int CzkAmount { get; set; }
        public int PlnAmount { get; set; }
        public int ChfAmount { get; set; }
        public int RubAmount { get; set; }
        
        public static explicit operator InvestmentPortfolioDto(InvestmentPortfolio portfolio) =>
            new InvestmentPortfolioDto()
            {
                UserId = portfolio.UserId,
                GbpAmount = portfolio.GbpAmount,
                EurAmount = portfolio.EurAmount,
                UsdAmount = portfolio.UsdAmount,
                CzkAmount = portfolio.CzkAmount,
                PlnAmount = portfolio.PlnAmount,
                ChfAmount = portfolio.ChfAmount,
                RubAmount = portfolio.RubAmount,
            };
    }
}