// ReSharper disable MemberHidesStaticFromOuterClass
namespace Byndyusoft.Net.YandexAuth.Internals.Errors;

using ModelResult;

/// <summary>
///     Ошибки авторизации и получении данных пользователя
/// </summary>
internal static class YandexErrors
{
    public static ErrorInfo VerifyCodeError(params ErrorInfoItem[] errorInfoItems) =>
        new(Codes.VerifyCodeError, "Возникла ошибка проверки кода авторизации от Yandex ID", errorInfoItems);

    public static ErrorInfo GetUserInfoError(params ErrorInfoItem[] errorInfoItems) =>
        new(Codes.GetUserInfoError, "Возникла ошибка получения информации о пользователе от Yandex ID", errorInfoItems);

    private static class Codes
    {
        public static string GetUserInfoError => "Yandex.GetUserInfo.Error";

        public static string VerifyCodeError => "Yandex.Verify.Error";
    }
}