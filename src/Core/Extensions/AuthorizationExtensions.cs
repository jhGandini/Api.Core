using Serede.CoreApi.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Serede.CoreApi.Extensions;

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
