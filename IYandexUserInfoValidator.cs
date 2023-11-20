namespace AuthorizationPackage;

using Byndyusoft.ModelResult;

public interface IYandexUserInfoValidator
{
    ErrorInfo? ValidateForAuthentication(UserInfoDto yandexUserInfoDto);

    ErrorInfo? ValidateForRegistration(UserInfoDto yandexUserInfoDto);
}