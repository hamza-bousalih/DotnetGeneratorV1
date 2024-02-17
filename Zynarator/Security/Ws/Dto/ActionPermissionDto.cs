using DotnetGenerator.Zynarator.Dto;

namespace DotnetGenerator.Zynarator.Security.Ws.Dto;

public class ActionPermissionDto : BaseDto
{
    public string? Reference { get; set; }
    public string? Libelle { get; set; }
}