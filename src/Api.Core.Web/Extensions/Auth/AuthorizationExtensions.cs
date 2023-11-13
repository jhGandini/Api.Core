using Api.Core.Web.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Core.Web.Extensions.Auth;

public static class AuthorizationExtensions
{
    public static void ConfigureAuthorization(this IServiceCollection services, IdentitySettings config)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("scopes", builder =>
            {
                foreach (string scope in config.Scopes)
                    builder.RequireScope(scope);

            });
        });
    }

}
