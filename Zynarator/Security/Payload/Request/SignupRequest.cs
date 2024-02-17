namespace DotnetGenerator.Zynarator.Security.Payload.Request;

public class SignupRequest
{
    public string Username = string.Empty;
    public string Email = string.Empty;
    public string Password = string.Empty;
    public ISet<string> Roles = new HashSet<string>();
}