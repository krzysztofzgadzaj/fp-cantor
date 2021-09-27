using MediatR;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Handlers.Commands.Base;
using User.Application.Handlers.Queries.Base;
using User.Infrastructure.Messaging.Commands;
using User.Infrastructure.Messaging.Queries;

namespace User.Infrastructure.Messaging
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