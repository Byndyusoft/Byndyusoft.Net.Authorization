namespace AuthorizationPackage.Internals.Implementations;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

[Service]
internal class JwtTokenService : IJwtTokenService
{
    private readonly JwtOptions _jwtOptions;

    public JwtTokenService(
        IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
        _jwtOptions.Validate();
    }

    public AccessTokenResult GenerateAccessToken(Claim[] claims)
    {
        var authSigningKey = JwtSecurity.GetSecurityKey(_jwtOptions.SecretKey);

        var date = DateTime.UtcNow;
        var token = new JwtSecurityToken(issuer: _jwtOptions.Issuer,
                                         audience: _jwtOptions.Audience,
                                         notBefore: date,
                                         expires: date.Add(_jwtOptions.Timeout),
                                         claims: claims,
                                         signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

        var handler = new JwtSecurityTokenHandler();
        var securityToken = handler.WriteToken(token);
        return new AccessTokenResult(securityToken, _jwtOptions.Timeout);
    }
}