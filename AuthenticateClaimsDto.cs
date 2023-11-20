namespace AuthorizationPackage;

using System.Collections.Generic;
using System.Security.Claims;

public class AuthenticateClaimsDto
{
    internal Dictionary<string, string> Claims { get; }

    public AuthenticateClaimsDto(string nameIdentifierClaim, string roleClaim)
    {
        Claims = new Dictionary<string, string>
                  {
                      { ClaimTypes.NameIdentifier, nameIdentifierClaim },
                      { ClaimTypes.Role, roleClaim }
                  };
    }

    public void AddAdditionalClaim(string claimType, string claimValue)
    {
        Claims.Add(claimType, claimValue);
    }

    public void AddAdditionalClaims(Dictionary<string, string> claims)
    {
        foreach (var (type, value) in claims) 
            Claims.Add(type, value);
    }
}