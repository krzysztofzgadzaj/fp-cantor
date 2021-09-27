using System;
using Cantor.Application.Contracts.Commands;

namespace Cantor.Application.Entities
{
    public class InvestmentPortfolio
    {
        public InvestmentPortfolio(Guid userId, int gbpAmount, int eurAmount, int usdAmount, int czkAmount, int plnAmount)
        {
            UserId = userId;
            GbpAmount = gbpAmount;
            EurAmount = eurAmount;
            UsdAmount = usdAmount;
            CzkAmount = czkAmount;
            PlnAmount = plnAmount;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int GbpAmount { get; set; }
        public int EurAmount { get; set; }
        public int UsdAmount { get; set; }
        public int CzkAmount { get; set; }
        public int PlnAmount { get; set; }

        public static explicit operator InvestmentPortfolio(CreateInvestmentPortfolioCommand command) =>
            new InvestmentPortfolio(
                command.UserId, 
                command.GbpAmount, 
                command.EurAmount,
                command.UsdAmount, 
                command.CzkAmount, 
                command.PlnAmount);
    }
}