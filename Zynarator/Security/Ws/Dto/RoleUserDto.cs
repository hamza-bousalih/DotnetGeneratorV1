using DotnetGenerator.Zynarator.Dto;

namespace DotnetGenerator.Zynarator.Security.Ws.Dto;

public class RoleUserDto : BaseDto
{
    public UserDto? User { get; set; }
    public RoleDto? Role { get; set; }
}