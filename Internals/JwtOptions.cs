namespace AuthorizationPackage.Internals;

using System;

internal class JwtOptions
{
    public string Issuer { get; set; } = default!;

    public string Audience { get; set; } = default!;

    public string SecretKey { get; set; } = default!;

    public TimeSpan Timeout { get; set; } = TimeSpan.FromHours(3);

    public TimeSpan RefreshTimeout { get; set; } = TimeSpan.FromDays(3);

    public TimeSpan ClockSkew { get; set; } = TimeSpan.FromSeconds(5);

    public void Validate()
    {
        if (string.IsNullOrEmpty(Issuer) || string.IsNullOrEmpty(Audience) || string.IsNullOrEmpty(SecretKey))
            throw new InvalidOperationException($"{nameof(Issuer)}, {nameof(Audience)} and {nameof(SecretKey)} must not be empty");

        if (Timeout < TimeSpan.FromSeconds(15))
            throw new InvalidOperationException($"{nameof(Timeout)} is less than 15 seconds");

        if (RefreshTimeout <= Timeout)
            throw new InvalidOperationException($"{nameof(RefreshTimeout)} must be greater than {nameof(Timeout)}");

        if (ClockSkew < TimeSpan.Zero)
            throw new InvalidOperationException($"{nameof(ClockSkew)} must be non-negative");
    }
}