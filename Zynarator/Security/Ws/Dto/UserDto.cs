using DotnetGenerator.Zynarator.Dto;

namespace DotnetGenerator.Zynarator.Security.Ws.Dto;

public class UserDto : BaseDto
{
    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? Phone { get; set; }


    public List<RoleUserDto>? RoleUsers { get; set; }
    public List<ModelPermissionUserDto>? ModelPermissionUsers { get; set; }
}