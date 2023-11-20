namespace AuthorizationPackage;

public interface IAuthenticationDtoGenerator
{
    AuthenticationTokenData Generate(AuthenticateClaimsDto dto, string refreshToken);
}