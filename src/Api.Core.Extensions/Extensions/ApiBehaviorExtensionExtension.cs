﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Core.Extensions.Extensions;

public static class ApiBehaviorExtensionExtension
{
    public static void SuppressModelStateInvalid(this IServiceCollection services, bool val = true)
    {
        services.Configure<ApiBehaviorOptions>(opt =>
        {
            opt.SuppressModelStateInvalidFilter = val;
        });
    }
}