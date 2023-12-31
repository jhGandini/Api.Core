﻿using Microsoft.AspNetCore.Authorization;

namespace Api.Core.Web.Extensions.Auth;

public static class AuthorizationPolicyBuilderExtensions
{
    public static AuthorizationPolicyBuilder RequireScope(this AuthorizationPolicyBuilder builder, params string[] scope)
    {
        return builder.RequireClaim("scope", scope);
    }
}