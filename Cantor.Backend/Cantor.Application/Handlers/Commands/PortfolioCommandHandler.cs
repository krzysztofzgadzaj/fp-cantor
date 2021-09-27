using System.Threading;
using System.Threading.Tasks;
using Cantor.Application.Contracts.Commands;
using Cantor.Application.Handlers.Commands.Base;
using Cantor.Application.Repositories;
using MediatR;

namespace Cantor.Application.Handlers.Commands
{
    public sealed class PortfolioCommandHandler : ICommandHandler<CreateInvestmentPortfolioCommand>,
        ICommandHandler<UpdateInvestmentPortfolioCommand>
    {
        private readonly ICantorRepository _cantorRepository;

        public PortfolioCommandHandler(ICantorRepository cantorRepository)
        {
            _cantorRepository = cantorRepository;
        }
        
        public async Task<Unit> Handle(CreateInvestmentPortfolioCommand request, CancellationToken cancellationToken)
        {
            await _cantorRepository.CreatePortfolio(request);

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateInvestmentPortfolioCommand request, CancellationToken cancellationToken)
        {
            await _cantorRepository.UpdatePortfolio(request);
            
            return Unit.Value;
        }
    }
}