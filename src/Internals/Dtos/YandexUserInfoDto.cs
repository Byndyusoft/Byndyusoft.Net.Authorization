﻿namespace Byndyusoft.Net.YandexAuth.Internals.Dtos;

using System.Text.Json.Serialization;

/// <summary>
///     Данные пользователя в системе YandexID
/// </summary>
internal class YandexUserInfoDto
{
    /// <summary>
    ///     Уникальный идентификатор пользователя Яндекса
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    /// <summary>
    ///     Имя пользователя
    /// </summary>
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = default!;

    /// <summary>
    ///     Фамилия пользователя
    /// </summary>
    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = default!;

    /// <summary>
    ///     Логин пользователя на Яндексе
    /// </summary>
    [JsonPropertyName("login")]
    public string Login { get; set; } = default!;

    /// <summary>
    ///     E-mail по умолчанию пользователя Яндекса.
    /// </summary>
    [JsonPropertyName("default_email")]
    public string DefaultEmail { get; set; } = default!;

    /// <summary>
    ///     Идентификатор портрета пользователя Яндекса
    /// </summary>
    [JsonPropertyName("default_avatar_id")]
    public string DefaultAvatarId { get; set; } = default!;

    /// <summary>
    ///     True, если вместо портрета заглушка
    /// </summary>
    [JsonPropertyName("is_avatar_empty")]
    public bool IsAvatarEmpty { get; set; }

    /// <summary>
    ///     Пол пользователя
    /// </summary>
    /// <remarks>
    ///     Возможные значения: male, female, null
    /// </remarks>
    [JsonPropertyName("sex")]
    public string? Sex { get; set; }
}