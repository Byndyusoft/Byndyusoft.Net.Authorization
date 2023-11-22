namespace Byndyusoft.Net.YandexAuth;

/// <summary>
///     Данные аутентификации пользователя в системе YandexID
/// </summary>
public class YandexAuthenticationData
{
    /// <summary>
    ///     Токен доступа
    /// </summary>
    public string AccessToken { get; set; } = default!;

    /// <summary>
    ///     Рефреш токен
    /// </summary>
    public string RefreshToken { get; set; } = default!;
}