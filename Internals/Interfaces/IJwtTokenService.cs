namespace AuthorizationPackage.Internals.Interfaces;

using System.Security.Claims;

internal interface IJwtTokenService
{
    public AccessTokenResult GenerateAccessToken(Claim[] claims);
}