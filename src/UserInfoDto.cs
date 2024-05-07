namespace Byndyusoft.Net.YandexAuth;

/// <summary>
///     Данные пользователя в системе YandexID
/// </summary>
public class UserInfoDto
{
    /// <summary>
    ///     Уникальный идентификатор пользователя Яндекса
    /// </summary>
    public string Id { get; set; } = default!;

    /// <summary>
    ///     Имя пользователя
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    ///     Фамилия пользователя
    /// </summary>
    public string LastName { get; set; } = default!;

    /// <summary>
    ///     Логин пользователя на Яндексе
    /// </summary>
    public string Login { get; set; } = default!;

    /// <summary>
    ///     E-mail по умолчанию пользователя Яндекса.
    /// </summary>
    public string DefaultEmail { get; set; } = default!;

    /// <summary>
    ///     Идентификатор портрета пользователя Яндекса
    /// </summary>
    public string DefaultAvatarId { get; set; } = default!;

    /// <summary>
    ///     True, если вместо портрета заглушка
    /// </summary>
    public bool IsAvatarEmpty { get; set; }

    /// <summary>
    ///     Пол пользователя
    /// </summary>
    /// <remarks>
    ///     Возможные значения: male, female, null
    /// </remarks>
    public string? Sex { get; set; }
}