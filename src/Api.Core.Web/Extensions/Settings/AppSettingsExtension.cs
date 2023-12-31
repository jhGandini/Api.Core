﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Api.Core.Web.Extensions.Settings;

public static class AppSettingsExtension
{
    public static IConfigurationRoot ConfigureAppSettings(this WebApplicationBuilder builder)
    {
        return builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables().Build();
    }
}
