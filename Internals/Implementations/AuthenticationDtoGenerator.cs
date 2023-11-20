namespace AuthorizationPackage.Internals.Implementations;

using Interfaces;

[Service]
internal class AuthenticationDtoGenerator : IAuthenticationDtoGenerator
{
    private readonly IEmployeeJwtTokenService _employeeJwtTokenService;

    public AuthenticationDtoGenerator(IEmployeeJwtTokenService employeeJwtTokenService)
    {
        _employeeJwtTokenService = employeeJwtTokenService;
    }

    public AuthenticationTokenData Generate(AuthenticateClaimsDto dto, string refreshToken)
    {
        var accessTokenResult = _employeeJwtTokenService.GenerateAccessToken(dto);

        return new AuthenticationTokenData
                   {
                       AccessToken = accessTokenResult.AccessToken,
                       RefreshToken = refreshToken,
                       ExpiresIn = (long)accessTokenResult.Timeout.TotalSeconds,
                       TokenType = "Bearer"
                   };
    }
}