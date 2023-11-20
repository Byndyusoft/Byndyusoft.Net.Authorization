namespace AuthorizationPackage.Internals.Implementations;

using System.Linq;
using System.Security.Claims;
using Interfaces;

[Service]
internal class EmployeeJwtTokenService : IEmployeeJwtTokenService
{
    private readonly IJwtTokenService _jwtTokenService;

    public EmployeeJwtTokenService(IJwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    public AccessTokenResult GenerateAccessToken(AuthenticateClaimsDto dto)
    {
        var authClaims = dto.Claims.Select(x => new Claim(x.Key, x.Value)).ToArray();

        return _jwtTokenService.GenerateAccessToken(authClaims.ToArray());
    }
}