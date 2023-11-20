using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Byndyusoft.ModelResult.ModelResults;

namespace AuthorizationPackage.Internals.Interfaces;

internal interface IYandexResponseProcessor
{
    Task<ModelResult<YandexOAuthResponseDto>> ProcessYandexOAuthResponseAsync(HttpResponseMessage httpResponseMessage, CancellationToken cancellationToken);
    Task<ModelResult<YandexUserInfo>> ProcessGetUserInfoResponseAsync(HttpResponseMessage httpResponseMessage, CancellationToken cancellationToken);
}