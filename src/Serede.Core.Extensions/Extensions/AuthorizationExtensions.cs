using Microsoft.Extensions.DependencyInjection;
using Serede.Core.Extensions.Settings;

namespace Serede.Core.Extensions;

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
