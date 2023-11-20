namespace AuthorizationPackage.Internals;

/// <summary>
///     Запрос на обновление токена доступа с помощью рефреш токена
/// </summary>
internal class RefreshYandexTokenRequestDto
{
    public RefreshYandexTokenRequestDto(string refreshToken, string clientId, string clientSecret)
    {
        RefreshToken = refreshToken;
        ClientId = clientId;
        ClientSecret = clientSecret;
    }

    /// <summary>
    ///     Рефреш токен
    /// </summary>
    public string RefreshToken { get; set; } = default!;

    /// <summary>
    ///     Идентификатор приложения Яндекса
    /// </summary>
    public string ClientId { get; set; } = default!;

    /// <summary>
    ///     Секретный ключ для приложения Яндекса
    /// </summary>
    public string ClientSecret { get; set; } = default!;
}