namespace AuthorizationPackage.Internals.Interfaces;

internal interface IEmployeeJwtTokenService
{
    public AccessTokenResult GenerateAccessToken(AuthenticateClaimsDto dto);
}