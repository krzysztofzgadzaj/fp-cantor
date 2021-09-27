using Cantor.Application.Handlers.Commands.Base;
using Cantor.Application.Handlers.Queries.Base;
using Cantor.Infrastructure.Messaging.Commands;
using Cantor.Infrastructure.Messaging.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Cantor.Infrastructure.Messaging
{
    public static class MessagingConfiguration
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services) =>
            services
                .AddScoped<IMediator, Mediator>()
                .AddScoped<ServiceFactory>(serviceProvider =>
                    serviceProvider.GetService)
                .AddScoped<ICommandBus, CommandBus>()
                .AddScoped<IQueryBus, QueryBus>();
    }
}