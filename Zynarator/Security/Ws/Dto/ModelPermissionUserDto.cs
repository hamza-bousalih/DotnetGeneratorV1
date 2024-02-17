using DotnetGenerator.Zynarator.Dto;

namespace DotnetGenerator.Zynarator.Security.Ws.Dto;

public class ModelPermissionUserDto : BaseDto
{
    public string? SubAttribute { get; set; }

    public ActionPermissionDto? ActionPermission { get; set; }
    public ModelPermissionDto? ModelPermission { get; set; }
    public UserDto? User { get; set; }
}