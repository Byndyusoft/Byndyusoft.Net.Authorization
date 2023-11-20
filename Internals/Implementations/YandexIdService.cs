namespace AuthorizationPackage.Internals.Implementations;

using System.Threading;
using System.Threading.Tasks;
using Byndyusoft.ModelResult.ModelResults;
using Interfaces;
using Microsoft.Extensions.Options;

[Service]
internal class YandexIdService : IYandexIdService
{
    private readonly IYandexAuthClient _yandexAuthClient;
    private readonly YandexIdOptions _yandexIdOptions;

    public YandexIdService(
        IOptions<YandexIdOptions> yandexIdOptions,
        IYandexAuthClient yandexAuthClient)
    {
        _yandexIdOptions = yandexIdOptions.Value;
        _yandexAuthClient = yandexAuthClient;

        _yandexIdOptions.Validate();
    }

    public async Task<ModelResult<YandexAuthenticationData>> GetAuthenticationDataByCodeAsync(
        string yandexVerificationCode, CancellationToken cancellationToken)
    {
        var getAccessTokenRequestDto =
            new VerifyCodeRequestDto(yandexVerificationCode, _yandexIdOptions.ClientId, _yandexIdOptions.ClientSecret);
        var getAccessTokenResponseDtoResult =
            await _yandexAuthClient.VerifyCodeAsync(getAccessTokenRequestDto, cancellationToken);

        if (getAccessTokenResponseDtoResult.IsError())
            return getAccessTokenResponseDtoResult.AsSimple();

        var authenticationData = getAccessTokenResponseDtoResult.Result;
        return new YandexAuthenticationData
               {
                   AccessToken = authenticationData.AccessToken,
                   RefreshToken = authenticationData.RefreshToken
               };
    }

    public async Task<ModelResult<YandexAuthenticationData>> GetAuthenticationDataByRefreshTokenAsync(
        string refreshToken, CancellationToken cancellationToken)
    {
        var getAccessTokenRequestDto =
            new RefreshYandexTokenRequestDto(refreshToken, _yandexIdOptions.ClientId, _yandexIdOptions.ClientSecret);
        var getAccessTokenResponseDtoResult =
            await _yandexAuthClient.RefreshTokenAsync(getAccessTokenRequestDto, cancellationToken);

        if (getAccessTokenResponseDtoResult.IsError())
            return getAccessTokenResponseDtoResult.AsSimple();

        var authenticationData = getAccessTokenResponseDtoResult.Result;
        return new YandexAuthenticationData
               {
                   AccessToken = authenticationData.AccessToken,
                   RefreshToken = authenticationData.RefreshToken
               };
    }

    public async Task<ModelResult<UserInfoDto>> GetUserInfo(string yandexIdAccessToken,
                                                         CancellationToken cancellationToken)
    {
        var yandexUserInfoResult = await _yandexAuthClient.GetUserInfo(yandexIdAccessToken, cancellationToken);
        if (yandexUserInfoResult.IsError())
            return yandexUserInfoResult.AsSimple();

        var yandexUserInfo = yandexUserInfoResult.Result;
        return new UserInfoDto
               {
                   Id = yandexUserInfo.Id,
                   Login = yandexUserInfo.Login,
                   FirstName = yandexUserInfo.FirstName,
                   LastName = yandexUserInfo.LastName,
                   Sex = yandexUserInfo.Sex,
                   DefaultAvatarId = yandexUserInfo.DefaultAvatarId,
                   IsAvatarEmpty = yandexUserInfo.IsAvatarEmpty,
               };
    }

    public string GetYandexAuthLink(string redirectToVerificationUrl, string? state = null)
    {
        var authLink = $"https://oauth.yandex.ru/authorize" +
                       $"?response_type=code" +
                       $"&client_id={_yandexIdOptions.ClientId}" +
                       $"&redirect_uri={redirectToVerificationUrl}";

        if (state != null)
            authLink += $"&state={state}";

        return authLink;
    }
}