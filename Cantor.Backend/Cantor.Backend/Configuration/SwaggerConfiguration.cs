using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Cantor.Backend.Configuration
{
    public static class SwaggerConfiguration
    {
        private const string SwaggerVersionKey = "Utility:Swagger:Version";
        private const string SwaggerNameKey = "Utility:Swagger:Name";
        private const string SwaggerUrlTemplate = "/swagger/{0}/swagger.json";
        private const string BearerAuthenticationName = "Bearer";
        private const string AuthorizationHeaderDescription = "JWT Authorization header used in the bearer scheme";
        private const string AuthorizationHeaderKey = "Authorization";

        public static IServiceCollection AddSwagger(this IServiceCollection services, 
            IConfiguration configuration)
        {
            var swaggerName = configuration.GetValue<string>(SwaggerNameKey);
            var swaggerVersion = configuration.GetValue<string>(SwaggerVersionKey);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(swaggerVersion, new OpenApiInfo()
                {
                    Title = swaggerName,
                    Version = swaggerVersion
                });
                
                options.AddSecurityDefinition(
                    BearerAuthenticationName,
                    new OpenApiSecurityScheme
                    {
                        Description = AuthorizationHeaderDescription,
                        Name = AuthorizationHeaderKey,
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = BearerAuthenticationName,
                    });

                options.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = BearerAuthenticationName,
                                },
                            },
                            Array.Empty<string>()
                        },
                    });
            });
            
            return services;
        }
        
        public static IApplicationBuilder AddSwaggerMiddleware(this IApplicationBuilder applicationBuilder,
            IConfiguration configuration)
        {
            var swaggerUrl = string.Format(SwaggerUrlTemplate, configuration.GetValue<string>(SwaggerVersionKey));
            var swaggerName = configuration.GetValue<string>(SwaggerNameKey);

            applicationBuilder
                .UseSwagger()
                .UseSwaggerUI(x => 
                {
                    x.SwaggerEndpoint(swaggerUrl, swaggerName);
                });

            return applicationBuilder;
        }
    }
}