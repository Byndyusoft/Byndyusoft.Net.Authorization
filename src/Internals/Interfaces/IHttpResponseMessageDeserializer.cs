namespace Byndyusoft.Net.YandexAuth.Internals.Interfaces;

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

/// <summary>
///     Десериализатор HTTP-ответа
/// </summary>
internal interface IHttpResponseMessageDeserializer
{
    /// <summary>
    ///     Десериализовать HTTP-ответ
    /// </summary>
    /// <typeparam name="T">Тип, в который нужно преобразовать ответ</typeparam>
    /// <param name="httpResponseMessage">HTTP-ответ</param>
    /// <param name="onErrorFunc">Функция, которая будет вызвана при ошибке десериализации</param>
    Task<T?> TryDeserializeAsync<T>(
        HttpResponseMessage httpResponseMessage,
        Action<HttpStatusCode, string>? onErrorFunc)
        where T : class;
}