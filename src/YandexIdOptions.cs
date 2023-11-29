namespace Byndyusoft.Net.YandexAuth;

using System;

/// <summary>
///     Переменные для работы с сервисом YandexID
/// </summary>
public class YandexIdOptions
{
    /// <summary>
    ///     Ид клиента (приложения)
    /// </summary>
    /// <remarks>Можно получить при регистрации приложения в серисе YandexID</remarks>
    public string ClientId { get; set; } = default!;

    /// <summary>
    ///     Ключ-секрет клиента (приложения)
    /// </summary>
    /// <remarks>Можно получить при регистрации приложения в серисе YandexID</remarks>
    public string ClientSecret { get; set; } = default!;
    
    public void Validate()
    {
        if (string.IsNullOrEmpty(ClientId) || string.IsNullOrEmpty(ClientSecret))
            throw new InvalidOperationException($"{nameof(ClientId)} and {nameof(ClientSecret)} must not be empty");
    }
}