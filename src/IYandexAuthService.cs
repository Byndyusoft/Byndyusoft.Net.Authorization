namespace Byndyusoft.Net.YandexAuth;

using System.Threading;
using System.Threading.Tasks;
using Byndyusoft.ModelResult.ModelResults;

/// <summary>
///     Сервис для работы с YandexID
/// </summary>
public interface IYandexAuthService
{
    /// <summary>
    ///     Получение данных аутентификации по коду верификации YandexID
    /// </summary>
    public Task<ModelResult<YandexAuthenticationData>> GetAuthenticationDataByCodeAsync(
        string yandexVerificationCode,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Получение данных аутентификации по рефреш токену YandexID
    /// </summary>
    public Task<ModelResult<YandexAuthenticationData>> GetAuthenticationDataByRefreshTokenAsync(
        string refreshToken,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Получение данных пользователя по токену доступа YandexID
    /// </summary>
    /// <remarks>Также валидирует данные, полученные от YandexID</remarks>
    public Task<ModelResult<UserInfoDto>> GetUserInfo(
        string yandexIdAccessToken,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Получение ссылки для перенаправления на сервис YandexID для получения данных аутентификации для пользователя
    /// </summary>
    /// <param name="redirectToVerificationUrl">Ссылка, куда будет направлен пользователь после аутентификации в сервисе YandexID</param>
    /// <param name="state">
    ///     Опциональная строка, которая будет возвращена YandexID в неизменном виде.
    ///     Может быть использована для сохранения адреса страницы к которой неавторизованный пользователь пытался получить доступ.
    /// </param>
    /// <returns>Ссылка, куда нужно перенаправить пользователя для аутентификации</returns>
    public string GetYandexAuthLink(string redirectToVerificationUrl, string? state = null);
}