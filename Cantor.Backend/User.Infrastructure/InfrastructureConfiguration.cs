using System;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Handlers.Commands.Base;
using User.Application.Services;
using User.Infrastructure.Controllers;
using User.Infrastructure.Messaging;
using User.Infrastructure.Messaging.Commands;
using User.Infrastructure.Persistence;
using User.Infrastructure.Services;

namespace User.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddUserInfrastructureDependencies(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddPersistenceConfiguration(configuration);
            serviceCollection.AddUserControllers(typeof(UserController));
            serviceCollection.AddUserControllers(typeof(AuthenticationController));
            serviceCollection.AddMessaging();
            serviceCollection.AddScoped<ITokenService, TokenService>();
            
            return serviceCollection;
        }

        private static void AddUserControllers(
            this IServiceCollection serviceCollection,
            Type controller) =>
                serviceCollection
                    .AddControllers()
                    .PartManager.ApplicationParts
                    .Add(new AssemblyPart(controller.Assembly));
    }
}