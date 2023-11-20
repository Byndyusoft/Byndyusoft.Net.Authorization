namespace AuthorizationPackage.Internals.Interfaces;

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

internal interface IHttpResponseMessageDeserializer
{
    Task<T?> TryDeserializeAsync<T>(
        HttpResponseMessage httpResponseMessage,
        Action<HttpStatusCode, string>? onErrorFunc)
        where T : class;
}