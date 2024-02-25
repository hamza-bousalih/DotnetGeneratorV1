using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Azure.Core;
using DotnetGenerator.Zynarator.Security.Common;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace DotnetGenerator.Zynarator.Security.Middleware;

public class JwtMiddleware: IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Method == RequestMethod.Options.Method)
        {
            await next(context);
            return;
        }
        
        if (context.Request.GetDisplayUrl().Contains("/auth"))
        {
            await next(context);
            return;
        }
        
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (token != null) AttachUserToContext(context, token);
        await next(context);
    }

    private static void AttachUserToContext(HttpContext context, string? token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtParams.Secret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var claims = jwtToken.Claims;
            
            var identity = new ClaimsIdentity(claims, "jwt");
            context.User = new ClaimsPrincipal(identity);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Token Validation Error: {ex.Message}");
        }
    }
}