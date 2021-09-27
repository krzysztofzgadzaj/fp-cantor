using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Cantor.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddCantorApplicationDependencies(this IServiceCollection services) =>
            services
                .AddMediatR(Assembly.GetExecutingAssembly());
    }
}