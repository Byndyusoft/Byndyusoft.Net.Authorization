// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

using Byndyusoft.Net.YandexAuth;
using Byndyusoft.Net.YandexAuth.Internals;
using Configuration;

public static class YandexAuthorizationInstaller
{
    /// <summary>
    ///     Регистрация зависимостей пакета для работы с сервисом YandexID
    /// </summary>
    public static IServiceCollection AddYandexAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        services.Scan(x => x.FromAssemblyOf<ServiceAttribute>()
                            .AddClasses(c => c.WithAttribute<ServiceAttribute>()).AsImplementedInterfaces()
                            .WithTransientLifetime());

        services.Configure<YandexIdOptions>(configuration.GetSection(nameof(YandexIdOptions)));

        return services;
    }
}