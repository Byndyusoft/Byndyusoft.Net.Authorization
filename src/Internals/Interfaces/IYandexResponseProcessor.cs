namespace Byndyusoft.Net.YandexAuth.Internals.Interfaces;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ModelResult.ModelResults;
using Dtos;

/// <summary>
///     Обработчик ответа от сервиса YandexID
/// </summary>
internal interface IYandexResponseProcessor
{
    /// <summary>
    ///     Обработка ответа аутентификации пользователя
    /// </summary>
    /// <param name="httpResponseMessage">HTTP-ответ</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные аутентификации пользователя</returns>
    Task<ModelResult<YandexOAuthResponseDto>> ProcessYandexOAuthResponseAsync(HttpResponseMessage httpResponseMessage, CancellationToken cancellationToken);

    /// <summary>
    ///     Обработка ответа получения данных о пользователе в системе YandexID
    /// </summary>
    /// <param name="httpResponseMessage">HTTP-ответ</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные пользователя</returns>
    Task<ModelResult<YandexUserInfoDto>> ProcessGetUserInfoResponseAsync(HttpResponseMessage httpResponseMessage, CancellationToken cancellationToken);
}