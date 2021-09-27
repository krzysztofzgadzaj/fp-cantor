using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace User.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddUserApplicationDependencies(this IServiceCollection services) =>
            services
                .AddMediatR(Assembly.GetExecutingAssembly());
    }
}