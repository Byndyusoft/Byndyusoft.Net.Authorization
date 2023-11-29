namespace Byndyusoft.Net.YandexAuth.Internals.Dtos;

internal class VerifyCodeRequestDto
{
    public VerifyCodeRequestDto()
    {
    }

    public VerifyCodeRequestDto(string code, string clientId, string clientSecret)
    {
        Code = code;
        ClientId = clientId;
        ClientSecret = clientSecret;
    }

    /// <summary>
    ///     Код подтверждения
    /// </summary>
    public string Code { get; set; } = default!;

    /// <summary>
    ///     Идентификатор приложения Яндекса
    /// </summary>
    public string ClientId { get; set; } = default!;

    /// <summary>
    ///     Секретный ключ для приложения Яндекса
    /// </summary>
    public string ClientSecret { get; set; } = default!;
}