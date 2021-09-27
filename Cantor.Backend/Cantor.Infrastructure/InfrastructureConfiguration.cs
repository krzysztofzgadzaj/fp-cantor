using System;
using Cantor.Infrastructure.Controllers;
using Cantor.Infrastructure.Messaging;
using Cantor.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cantor.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddCantorInfrastructureDependencies(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddPersistenceConfiguration(configuration);
            serviceCollection.AddCantorControllers(typeof(CantorController));
            serviceCollection.AddMessaging();

            return serviceCollection;
        }

        private static void AddCantorControllers(
            this IServiceCollection serviceCollection,
            Type controller) =>
            serviceCollection
                .AddControllers()
                .PartManager.ApplicationParts
                .Add(new AssemblyPart(controller.Assembly));
    }
}