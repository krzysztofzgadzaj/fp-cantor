using System.Threading.Tasks;
using Cantor.Application.Contracts.Commands;
using Cantor.Application.Contracts.Queries;
using Cantor.Application.Entities;

namespace Cantor.Application.Repositories
{
    public interface ICantorRepository
    {
        Task CreatePortfolio(CreateInvestmentPortfolioCommand request);
        Task UpdatePortfolio(UpdateInvestmentPortfolioCommand request);
        Task<InvestmentPortfolio> GetPortfolio(GetInvestmentPortfolioQuery request);
    }
}