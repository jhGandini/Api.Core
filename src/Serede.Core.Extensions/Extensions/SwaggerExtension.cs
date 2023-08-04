using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
namespace Serede.Core.Extensions;

public static class SwaggerExtension
{
    public static void ConfigureSwagger(this IServiceCollection services, OpenApiInfo info = null)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = info?.Title,
                    Version = info?.Version,
                    Description = info?.Description,
                    Contact = new OpenApiContact
                    {
                        Name = info?.Contact?.Name,
                        Url = new Uri(info?.Contact?.Url.ToString())
                    }
                }
            );
            c.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header utiliza esquema Bearer. 
                            Coloque 'Bearer' [espaço] e insira seu token.
                            Exemplo: 'Bearer 12345abcdef'",
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
    }


}
