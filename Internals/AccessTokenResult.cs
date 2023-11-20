namespace AuthorizationPackage.Internals;

using System;

internal class AccessTokenResult
{
    internal AccessTokenResult(string accessToken, TimeSpan timeout)
    {
        AccessToken = accessToken;
        Timeout = timeout;
    }

    public string AccessToken { get; }

    public TimeSpan Timeout { get; }
}