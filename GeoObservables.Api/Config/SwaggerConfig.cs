using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GeoObservables.Api.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            var xmlPath = Path.Combine(basePath, xmlFile);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GeoObservables API V1",
                    Version = "v1",
                    Description = "GeoObservable API net core",
                    Contact = new OpenApiContact
                    {
                        Name = "Alberto Carballo",
                        Email = "alberto.carballo@hotmail.com",
                        Url = new Uri("https://twitter.com/acarballo")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under XXX",
                        Url = new Uri("https://example.com/license")
                    }
                });
                c.IncludeXmlComments(xmlPath);

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                          Reference = new OpenApiReference
                            {
                              Type = ReferenceType.SecurityScheme,
                              Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                          },
                         new List<string>()
                    }
                });
            });

            return services;
        }

        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app, WebApplicationBuilder builder)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthClientId("swagger-ui");
                c.OAuthClientSecret("swagger-ui-secret");
                c.OAuthRealm("swagger-ui-realm");
                c.OAuthAppName("Swagger UI");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GeoObservable API V1");
                c.InjectStylesheet("/swagger/ui/custom.css");
            });
            app.UseStaticFiles();

            return app;
        }
    }
}
