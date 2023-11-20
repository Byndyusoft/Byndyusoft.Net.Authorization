// ReSharper disable MemberHidesStaticFromOuterClass
namespace AuthorizationPackage.Internals;

using Byndyusoft.ModelResult;

internal static class AuthErrors
{
    public static ErrorInfo EmailMustBeCorporate() =>
        new(Codes.EmailMustBeCorporate, "Логин должен быть корпоративной почтой @byndyusoft.com");

    public static ErrorInfo InvalidUserInfo(params ErrorInfoItem[] errorInfoItems) =>
        new(Codes.InvalidUserInfo, "Не все поля валидны в информации о пользователе Яндекса", errorInfoItems);

    public static ErrorInfo TokenNotFoundOrExpired() =>
        new(Codes.TokenNotFoundOrExpired, "Не найден токен, или истек срок его действия");

    public static ErrorInfo UserCannotCreateToken() =>
        new(Codes.UserCannotCreateToken, "У уволенного пользователя нет возможности авторизоваться");

    public static class Codes
    {
        public static string EmailMustBeCorporate => "Auth.EmailMustBeCorporate";

        public static string InvalidUserInfo => "Auth.InvalidUserInfo";

        public static string TokenNotFoundOrExpired => "Auth.TokenNotFoundOrExpired";

        public static string UserCannotCreateToken => "Auth.UserCannotCreateToken";
    }
}