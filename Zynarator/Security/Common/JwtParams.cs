namespace DotnetGenerator.Zynarator.Security.Common;

public interface JwtParams
{
    static readonly string ValidIssuer = "https://localhost:7231";
    static readonly string ValidAudience = "https://localhost:4200";
    static readonly string Secret = "b666c3f1-0636-4990-ba35-4f7110d75f57";
    static readonly string JwtHeader = "Authorization";
    static readonly string JwtPrefix = "Bearer ";
    static readonly long Expiration = 86400000;

}