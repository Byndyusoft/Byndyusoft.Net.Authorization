namespace AuthorizationPackage;

/// <summary>
///     ДТО с информацией об аутентификации
/// </summary>
public class AuthenticationTokenData
{
    /// <summary>
    ///     Токен для авторизации
    /// </summary>
    public string AccessToken { get; set; } = default!;

    /// <summary>
    ///     Токен для обновления токена авториации
    /// </summary>
    public string RefreshToken { get; set; } = default!;

    /// <summary>
    ///     Таймаут токена авторизации в секундах
    /// </summary>
    public long ExpiresIn { get; set; }

    /// <summary>
    ///     Тип токена
    /// </summary>
    public string TokenType { get; set; } = default!;
}