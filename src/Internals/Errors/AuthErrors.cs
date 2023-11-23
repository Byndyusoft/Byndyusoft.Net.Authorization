// ReSharper disable MemberHidesStaticFromOuterClass
namespace Byndyusoft.Net.YandexAuth.Internals.Errors;

using ModelResult;

/// <summary>
///     Ошибки аутентификации
/// </summary>
internal static class AuthErrors
{
    public static ErrorInfo InvalidUserInfo(params ErrorInfoItem[] errorInfoItems) =>
        new(Codes.InvalidUserInfo, "Не все поля валидны в информации о пользователе Яндекса", errorInfoItems);

    public static ErrorInfo TokenNotFoundOrExpired() =>
        new(Codes.TokenNotFoundOrExpired, "Не найден токен, или истек срок его действия");

    private static class Codes
    {
        public static string InvalidUserInfo => "Auth.InvalidUserInfo";

        public static string TokenNotFoundOrExpired => "Auth.TokenNotFoundOrExpired";
    }
}