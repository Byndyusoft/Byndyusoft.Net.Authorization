namespace AuthorizationPackage;

using System.Threading;
using System.Threading.Tasks;
using Byndyusoft.ModelResult.ModelResults;

public interface IYandexIdService
{
    public Task<ModelResult<YandexAuthenticationData>> GetAuthenticationDataByCodeAsync(
        string yandexVerificationCode,
        CancellationToken cancellationToken);

    public Task<ModelResult<YandexAuthenticationData>> GetAuthenticationDataByRefreshTokenAsync(
        string refreshToken,
        CancellationToken cancellationToken);

    public Task<ModelResult<UserInfoDto>> GetUserInfo(
        string yandexIdAccessToken, 
        CancellationToken cancellationToken);

    public string GetYandexAuthLink(string redirectToVerificationUrl, string? state = null);
}