using Cantor.Application.Repositories;
using Cantor.Infrastructure.Persistence.Context;
using Cantor.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cantor.Infrastructure.Persistence
{
    internal static class PersistenceConfiguration
    {
        private const string ConnectionStringName = "CantorDbConnection";

        internal static IServiceCollection AddPersistenceConfiguration(
            this IServiceCollection serviceCollection,
            IConfiguration configuration) =>
            serviceCollection
                .AddDbContext<CantorContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString(ConnectionStringName)))
                .AddScoped<ICantorRepository, CantorRepository>();
    }
}