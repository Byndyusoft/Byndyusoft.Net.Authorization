using System;
using Byndyusoft.ModelResult;

namespace AuthorizationPackage.Internals.Implementations;

[Service]
internal class YandexUserInfoValidator : IYandexUserInfoValidator
{
    private const string ExpectedEmailPostfix = "@byndyusoft.com";

    public ErrorInfo? ValidateForAuthentication(UserInfoDto yandexUserInfo)
    {
        var fluentValidator = new YandexUserInfoFluentValidator();
        var errorInfoItems = fluentValidator.ValidateAndGetErrorInfoItems(yandexUserInfo);
        if (errorInfoItems.Length == 0)
            return null;

        return AuthErrors.InvalidUserInfo(errorInfoItems);
    }

    public ErrorInfo? ValidateForRegistration(UserInfoDto yandexUserInfo)
    {
        if (yandexUserInfo.Login.EndsWith(ExpectedEmailPostfix, StringComparison.InvariantCultureIgnoreCase) == false)
            return AuthErrors.EmailMustBeCorporate();
        return null;
    }
}