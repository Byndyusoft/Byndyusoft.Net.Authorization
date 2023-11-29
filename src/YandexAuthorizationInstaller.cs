// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

using Byndyusoft.Net.YandexAuth;
using Byndyusoft.Net.YandexAuth.Internals.Implementations;
using Byndyusoft.Net.YandexAuth.Internals.Interfaces;
using Configuration;

public static class YandexAuthorizationInstaller
{
    /// <summary>
    ///     Регистрация зависимостей пакета для работы с сервисом YandexID
    /// </summary>
    public static IServiceCollection AddYandexAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IHttpResponseMessageDeserializer, HttpResponseMessageDeserializer>();
        services.AddTransient<IYandexAuthClient, YandexAuthClient>();
        services.AddTransient<IYandexAuthService, YandexAuthService>();
        services.AddTransient<IYandexResponseProcessor, YandexResponseProcessor>();

        services.Configure<YandexIdOptions>(configuration.GetSection(nameof(YandexIdOptions)));

        return services;
    }
}