namespace Byndyusoft.Net.YandexAuth.Internals.Implementations;

using System.Linq;
using ModelResult;
using Dtos;
using Errors;

internal static class YandexUserInfoValidator
{
    public static ErrorInfo? ValidateForAuthentication(YandexUserInfoDto yandexUserInfo)
    {
        var errorItems = new ErrorInfoItem?[]
                         {
                             Validate(nameof(yandexUserInfo.Login), yandexUserInfo.Login),
                             Validate(nameof(yandexUserInfo.FirstName), yandexUserInfo.FirstName),
                             Validate(nameof(yandexUserInfo.LastName), yandexUserInfo.LastName),
                             Validate(nameof(yandexUserInfo.Id), yandexUserInfo.Id),
                             Validate(nameof(yandexUserInfo.DefaultAvatarId), yandexUserInfo.DefaultAvatarId),
                         };

        return errorItems.Any(error => error != null)
            ? AuthErrors.InvalidUserInfo(errorItems.Where(x => x != null).Select(x => x!).ToArray())
            : null;
    }

    private static ErrorInfoItem? Validate(string propertyName, string value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? new ErrorInfoItem(propertyName, $"{propertyName} should is null or empty.")
            : null;
    }
}