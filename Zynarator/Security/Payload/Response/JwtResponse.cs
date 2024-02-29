namespace DotnetGenerator.Zynarator.Security.Payload.Response;

public class JwtResponse
{
    public string AccessToken = string.Empty;
    public string Type = "Bearer";
    public string Id = string.Empty;
    public string? Username;
    public string? Email;
    public ISet<string>? Roles;
}