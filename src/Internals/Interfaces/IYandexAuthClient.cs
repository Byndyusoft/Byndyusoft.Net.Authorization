namespace Byndyusoft.Net.YandexAuth.Internals.Interfaces;

using System.Threading;
using System.Threading.Tasks;
using ModelResult.ModelResults;
using Dtos;

/// <summary>
///     Клиент аутентификации и авторизации в YandexID
/// </summary>
internal interface IYandexAuthClient
{
    /// <summary>
    ///     Запрос проверки кода доступа и получение данных аутентификации по коду.
    /// </summary>
    Task<ModelResult<YandexOAuthResponseDto>> VerifyCodeAsync(VerifyCodeRequestDto requestDto, CancellationToken cancellationToken);

    /// <summary>
    ///     Запрос проверки рефреш токена и получение данных аутентификации по токену.
    /// </summary>
    Task<ModelResult<YandexOAuthResponseDto>> RefreshTokenAsync(RefreshYandexTokenRequestDto requestDto, CancellationToken cancellationToken);

    /// <summary>
    ///     Получения данных о пользователе по токену доступа.
    Task<ModelResult<YandexUserInfoDto>> GetUserInfo(string accessToken, CancellationToken cancellationToken);
}