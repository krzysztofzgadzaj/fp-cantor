using Cantor.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cantor.Infrastructure.Persistence.Context
{
    public sealed class CantorContext : DbContext
    {
        public const string SchemaName = "InvestmentPortfolios";

        public CantorContext(DbContextOptions<CantorContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }
        
        public DbSet<InvestmentPortfolio> Portfolios { get; set; }
    }
}