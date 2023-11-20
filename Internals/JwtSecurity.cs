namespace AuthorizationPackage.Internals;

using System.Text;
using Microsoft.IdentityModel.Tokens;

internal static class JwtSecurity
{
    public static SecurityKey GetSecurityKey(string secretKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
    }
}