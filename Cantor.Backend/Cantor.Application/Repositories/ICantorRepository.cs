using System.Threading.Tasks;
using Cantor.Application.Contracts.Commands;

namespace Cantor.Application.Repositories
{
    public interface ICantorRepository
    {
        Task CreatePortfolio(CreateInvestmentPortfolioCommand request);
        Task UpdatePortfolio(UpdateInvestmentPortfolioCommand request);
    }
}