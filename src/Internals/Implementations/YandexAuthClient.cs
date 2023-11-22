namespace Byndyusoft.Net.YandexAuth.Internals.Implementations;

using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Byndyusoft.ModelResult.ModelResults;
using Dtos;
using Interfaces;

[Service]
internal class YandexAuthClient : IYandexAuthClient
{
    private readonly HttpClient _httpClient;
    private readonly IYandexResponseProcessor _yandexResponseProcessor;

    public YandexAuthClient(
        HttpClient httpClient,
        IYandexResponseProcessor yandexResponseProcessor)
    {
        _httpClient = httpClient;
        _yandexResponseProcessor = yandexResponseProcessor;
    }

    public async Task<ModelResult<YandexOAuthResponseDto>> VerifyCodeAsync(VerifyCodeRequestDto requestDto, CancellationToken cancellationToken)
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
                                                    {
                                                        { "grant_type", "authorization_code" },
                                                        { "code", requestDto.Code },
                                                        { "client_id", requestDto.ClientId },
                                                        { "client_secret", requestDto.ClientSecret }
                                                    });
        using var httpResponseMessage = await _httpClient.PostAsync("https://oauth.yandex.ru/token", content, cancellationToken);
        return await _yandexResponseProcessor.ProcessYandexOAuthResponseAsync(httpResponseMessage, cancellationToken);
    }

    public async Task<ModelResult<YandexOAuthResponseDto>> RefreshTokenAsync(RefreshYandexTokenRequestDto requestDto, CancellationToken cancellationToken)
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
                                                    {
                                                        { "grant_type", "refresh_token" },
                                                        { "refresh_token", requestDto.RefreshToken },
                                                        { "client_id", requestDto.ClientId },
                                                        { "client_secret", requestDto.ClientSecret }
                                                    });
        using var httpResponseMessage = await _httpClient.PostAsync("https://oauth.yandex.ru/token", content, cancellationToken);
        return await _yandexResponseProcessor.ProcessYandexOAuthResponseAsync(httpResponseMessage, cancellationToken);
    }

    public async Task<ModelResult<YandexUserInfoDto>> GetUserInfo(string accessToken, CancellationToken cancellationToken)
    {
        using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://login.yandex.ru/info?format=json");
        httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("OAuth", accessToken);
        using var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);
        return await _yandexResponseProcessor.ProcessGetUserInfoResponseAsync(httpResponseMessage, cancellationToken);
    }
}