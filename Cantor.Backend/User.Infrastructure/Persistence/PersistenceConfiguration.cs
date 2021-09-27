using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Repositories;
using User.Infrastructure.Persistence.Context;
using User.Infrastructure.Persistence.Repositories;

namespace User.Infrastructure.Persistence
{
    internal static class PersistenceConfiguration
    {
        private const string ConnectionStringName = "CantorDbConnection";

        internal static IServiceCollection AddPersistenceConfiguration(
            this IServiceCollection serviceCollection,
            IConfiguration configuration) =>
            serviceCollection
                .AddDbContext<UserContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString(ConnectionStringName)))
                .AddScoped<IUserRepository, UserRepository>();
    }
}