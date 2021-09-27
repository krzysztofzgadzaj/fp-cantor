using Cantor.Application;
using Cantor.Backend.Configuration;
using Cantor.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using User.Application;
using User.Infrastructure;

namespace Cantor.Backend
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services) =>
            services
                .AddUserApplicationDependencies()
                .AddUserInfrastructureDependencies(_configuration)
                .AddCantorApplicationDependencies()
                .AddCantorInfrastructureDependencies(_configuration)
                .AddSwagger(_configuration);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.AddSwaggerMiddleware(_configuration);
        }
    }
}