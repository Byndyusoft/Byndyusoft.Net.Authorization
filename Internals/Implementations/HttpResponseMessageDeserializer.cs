namespace AuthorizationPackage.Internals.Implementations;

using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.Extensions.Logging;

[Service]
internal class HttpResponseMessageDeserializer : IHttpResponseMessageDeserializer
{
    private readonly ILogger<HttpResponseMessageDeserializer> _logger;

    public HttpResponseMessageDeserializer(ILogger<HttpResponseMessageDeserializer> logger)
    {
        _logger = logger;
    }

    public async Task<T?> TryDeserializeAsync<T>(
        HttpResponseMessage httpResponseMessage,
        Action<HttpStatusCode, string>? onErrorFunc)
        where T : class
    {
        if (httpResponseMessage.IsSuccessStatusCode == false)
        {
            var errorString = await httpResponseMessage.Content.ReadAsStringAsync();
            onErrorFunc?.Invoke(httpResponseMessage.StatusCode, errorString);

            return null;
        }

        try
        {
            var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<T>(responseString);
            if (response is null)
            {
                var errorMessage = "Десериализация результата вернула null";
                _logger.LogError(errorMessage);
                onErrorFunc?.Invoke(httpResponseMessage.StatusCode, errorMessage);
                return null;
            }

            return response;
        }
        catch (Exception exception)
        {
            var errorString = "Ошибка десериализации";
            _logger.LogError(exception, errorString);
            onErrorFunc?.Invoke(httpResponseMessage.StatusCode, errorString);

            return null;
        }
    }
}