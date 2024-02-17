using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotnetGenerator.Zynarator.Security.Common;
using Microsoft.IdentityModel.Tokens;

namespace DotnetGenerator.Zynarator.Security.Jwt;

public class JwtUtils
{
    public static string GenerateToken(IEnumerable<Claim> claims)
    {
        var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtParams.Secret));

        var tokenObject = new JwtSecurityToken(
            issuer: JwtParams.ValidIssuer,
            audience: JwtParams.ValidAudience,
            expires: DateTime.Now.AddSeconds(JwtParams.Expiration),
            claims: claims,
            signingCredentials: new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256)
        );

        var token = new JwtSecurityTokenHandler().WriteToken(tokenObject);

        return token;
    }
}