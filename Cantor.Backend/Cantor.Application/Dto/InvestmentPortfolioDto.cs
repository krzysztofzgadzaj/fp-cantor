using System;

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
    }
}