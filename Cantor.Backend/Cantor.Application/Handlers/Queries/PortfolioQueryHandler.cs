using System.Threading;
using System.Threading.Tasks;
using Cantor.Application.Contracts.Queries;
using Cantor.Application.Dto;
using Cantor.Application.Handlers.Queries.Base;
using Cantor.Application.Repositories;

namespace Cantor.Application.Handlers.Queries
{
    public class PortfolioQueryHandler : IQueryHandler<GetInvestmentPortfolioQuery, InvestmentPortfolioDto>
    {
        private readonly ICantorRepository _cantorRepository;

        public PortfolioQueryHandler(ICantorRepository cantorRepository)
        {
            _cantorRepository = cantorRepository;
        }
        
        public async Task<InvestmentPortfolioDto> Handle(GetInvestmentPortfolioQuery request, CancellationToken cancellationToken)
        {
            var portfolio = await _cantorRepository.GetPortfolio(request);
            var portfolioDto = (InvestmentPortfolioDto) portfolio;

            return portfolioDto;
        }
    }
}