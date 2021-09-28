using System.Threading.Tasks;
using Cantor.Application.Contracts.Commands;
using Cantor.Application.Contracts.Queries;
using Cantor.Application.Entities;
using Cantor.Application.Repositories;
using Cantor.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Cantor.Infrastructure.Persistence.Repositories
{
    public sealed class CantorRepository : ICantorRepository
    {
        private readonly CantorContext _cantorContext;
        
        public CantorRepository(CantorContext cantorContext)
        {
            _cantorContext = cantorContext;
        }

        public async Task CreatePortfolio(CreateInvestmentPortfolioCommand request)
        {
            var investmentPortfolio = (InvestmentPortfolio) request;
            
            await _cantorContext.AddAsync(investmentPortfolio);
            await _cantorContext.SaveChangesAsync();
        }

        public async Task UpdatePortfolio(UpdateInvestmentPortfolioCommand request)
        {
            var investmentPortfolio = 
                await _cantorContext.Portfolios
                    .FirstOrDefaultAsync(x => x.UserId == request.UserId);

            investmentPortfolio.CzkAmount = request.CzkAmount;
            investmentPortfolio.EurAmount = request.EurAmount;
            investmentPortfolio.GbpAmount = request.GbpAmount;
            investmentPortfolio.PlnAmount = request.PlnAmount;
            investmentPortfolio.UsdAmount = request.UsdAmount;

            _cantorContext.Update(investmentPortfolio);
            await _cantorContext.SaveChangesAsync();
        }

        public async Task<InvestmentPortfolio> GetPortfolio(GetInvestmentPortfolioQuery request)
        {
            var userId = request.UserId;
            var portfolio = await _cantorContext.Portfolios.FirstOrDefaultAsync(x => x.UserId == userId);

            return portfolio;
        }
    }
}