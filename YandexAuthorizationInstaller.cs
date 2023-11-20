// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

using System;
using AspNetCore.Authentication.JwtBearer;
using AuthorizationPackage;
using AuthorizationPackage.Internals;
using Configuration;
using IdentityModel.Tokens;

public static class YandexAuthorizationInstaller
{
    public static IServiceCollection AddYandexAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        AddJwtAuthorization(services, configuration);

        services.Scan(x => x.FromAssemblyOf<ServiceAttribute>()
                            .AddClasses(c => c.WithAttribute<ServiceAttribute>()).AsImplementedInterfaces()
                            .WithTransientLifetime());

        services.Configure<YandexIdOptions>(configuration.GetSection(nameof(YandexIdOptions)));
        services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

        return services;
    }

    private static void AddJwtAuthorization(IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
        if (jwtOptions == null)
            throw new ArgumentException("Jwt options are missing. Please check service configuration.");

        jwtOptions.Validate();

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
                          o =>
                          {
                              o.IncludeErrorDetails = true;
                              o.Audience = jwtOptions.Audience;
                              o.TokenValidationParameters =
                                  new TokenValidationParameters
                                  {
                                      ValidateIssuerSigningKey = true,
                                      IssuerSigningKey = JwtSecurity.GetSecurityKey(jwtOptions.SecretKey),
                                      ValidateLifetime = true,
                                      ClockSkew = jwtOptions.ClockSkew,
                                      ValidateAudience = true,
                                      ValidateIssuer = false,
                                      ValidateActor = false
                                  };
                          });
    }
}