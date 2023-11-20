namespace AuthorizationPackage;

using System;

public class YandexIdOptions
{
    public string ClientId { get; set; } = default!;

    public string ClientSecret { get; set; } = default!;

    public void Validate()
    {
        if (string.IsNullOrEmpty(ClientId) || string.IsNullOrEmpty(ClientSecret))
            throw new InvalidOperationException($"{nameof(ClientId)} and {nameof(ClientSecret)} must not be empty");
    }
}