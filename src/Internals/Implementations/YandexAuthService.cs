namespace Byndyusoft.Net.YandexAuth.Internals.Implementations;

using System.Threading;
using System.Threading.Tasks;
using ModelResult.ModelResults;
using Dtos;
using Interfaces;
using Microsoft.Extensions.Options;
using Validators;

internal class YandexAuthService : IYandexAuthService
{
    private readonly IYandexAuthClient _yandexAuthClient;
    private readonly YandexIdOptions _yandexIdOptions;

    public YandexAuthService(
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

        if (getAccessTokenResponseDtoResult.TryGetResult(out var authenticationData) == false)
            return getAccessTokenResponseDtoResult.AsSimple();

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

        if (getAccessTokenResponseDtoResult.TryGetResult(out var authenticationData) == false)
            return getAccessTokenResponseDtoResult.AsSimple();

        return new YandexAuthenticationData
        {
            AccessToken = authenticationData.AccessToken,
            RefreshToken = authenticationData.RefreshToken
        };
    }

    public async Task<ModelResult<UserInfoDto>> GetUserInfo(string yandexIdAccessToken, CancellationToken cancellationToken)
    {
        var yandexUserInfoResult = await _yandexAuthClient.GetUserInfo(yandexIdAccessToken, cancellationToken);
        if (yandexUserInfoResult.TryGetResult(out var yandexUserInfo) == false)
            return yandexUserInfoResult.AsSimple();

        var errorInfo = YandexUserInfoValidator.ValidateForAuthentication(yandexUserInfo);
        if (errorInfo is not null)
            return new ErrorModelResult(errorInfo);

        return new UserInfoDto
        {
            Id = yandexUserInfo.Id,
            Login = yandexUserInfo.Login,
            DefaultEmail = yandexUserInfo.DefaultEmail,
            FirstName = yandexUserInfo.FirstName,
            LastName = yandexUserInfo.LastName,
            Sex = yandexUserInfo.Sex,
            DefaultAvatarId = yandexUserInfo.DefaultAvatarId,
            IsAvatarEmpty = yandexUserInfo.IsAvatarEmpty
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