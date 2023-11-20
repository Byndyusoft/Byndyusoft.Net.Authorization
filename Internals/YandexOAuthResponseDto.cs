namespace AuthorizationPackage.Internals;

using System.Text.Json.Serialization;

internal class YandexOAuthResponseDto
{
    /// <summary>
    ///     OAuth токен из Яндекса
    /// </summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = default!;

    /// <summary>
    ///     Время жизни токена
    /// </summary>
    [JsonPropertyName("expires_in")]
    public long ExpiresIn { get; set; }

    /// <summary>
    ///     Рефреш токен из Яндекса
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = default!;

    /// <summary>
    ///     Тип токена
    /// </summary>
    /// <remarks>
    ///     Всегда Bearer
    /// </remarks>
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = default!;
}