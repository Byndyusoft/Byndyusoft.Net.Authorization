namespace Byndyusoft.Net.YandexAuth.Internals.Implementations;

using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Byndyusoft.ModelResult.ModelResults;
using Dtos;
using Errors;
using Interfaces;
using Microsoft.Extensions.Logging;

[Service]
internal class YandexResponseProcessor : IYandexResponseProcessor
{
    private readonly ILogger<YandexResponseProcessor> _logger;
    private readonly IHttpResponseMessageDeserializer _httpResponseMessageDeserializer;

    public YandexResponseProcessor(
        ILogger<YandexResponseProcessor> logger,
        IHttpResponseMessageDeserializer httpResponseMessageDeserializer)
    {
        _logger = logger;
        _httpResponseMessageDeserializer = httpResponseMessageDeserializer;
    }

    public async Task<ModelResult<YandexOAuthResponseDto>> ProcessYandexOAuthResponseAsync(
        HttpResponseMessage httpResponseMessage,
        CancellationToken cancellationToken)
    {
        var getAccessTokenResponseDto = await _httpResponseMessageDeserializer
                                            .TryDeserializeAsync<YandexOAuthResponseDto>(httpResponseMessage, OnVerifyCodeError);
        if (getAccessTokenResponseDto is null)
            return new ErrorModelResult(YandexErrors.VerifyCodeError());

        return getAccessTokenResponseDto;
    }

    public async Task<ModelResult<YandexUserInfoDto>> ProcessGetUserInfoResponseAsync(
        HttpResponseMessage httpResponseMessage,
        CancellationToken cancellationToken)
    {
        var yandexUserInfo = await _httpResponseMessageDeserializer.
                                 TryDeserializeAsync<YandexUserInfoDto>(httpResponseMessage, OnGetUserInfoError);
        if (yandexUserInfo is null)
            return new ErrorModelResult(YandexErrors.GetUserInfoError());

        return yandexUserInfo;
    }

    private void OnVerifyCodeError(HttpStatusCode httpStatusCode, string errorString)
    {
        _logger.LogError("Ошибка проверки кода: {ErrorString}; HttpCode = {HttpStatusCode}", errorString, httpStatusCode);
    }

    private void OnGetUserInfoError(HttpStatusCode httpStatusCode, string errorString)
    {
        _logger.LogError("Ошибка получения информации о пользователе: {ErrorString}; HttpCode = {HttpStatusCode}", errorString, httpStatusCode);
    }
}