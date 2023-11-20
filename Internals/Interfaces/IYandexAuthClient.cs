using System.Threading;
using System.Threading.Tasks;
using Byndyusoft.ModelResult.ModelResults;

namespace AuthorizationPackage.Internals.Interfaces;

internal interface IYandexAuthClient
{
    Task<ModelResult<YandexOAuthResponseDto>> VerifyCodeAsync(VerifyCodeRequestDto requestDto, CancellationToken cancellationToken);
    Task<ModelResult<YandexOAuthResponseDto>> RefreshTokenAsync(RefreshYandexTokenRequestDto requestDto, CancellationToken cancellationToken);
    Task<ModelResult<YandexUserInfo>> GetUserInfo(string accessToken, CancellationToken cancellationToken);
}