namespace Byndyusoft.Net.YandexAuth.Internals.Implementations;

using Byndyusoft.ModelResult;
using Dtos;
using Errors;
using Extensions;

internal static class YandexUserInfoValidator
{
    public static ErrorInfo? ValidateForAuthentication(YandexUserInfoDto yandexUserInfo)
    {
        var fluentValidator = new YandexUserInfoFluentValidator();
        var errorInfoItems = fluentValidator.ValidateAndGetErrorInfoItems(yandexUserInfo);
        if (errorInfoItems.Length == 0)
            return null;

        return AuthErrors.InvalidUserInfo(errorInfoItems);
    }
}