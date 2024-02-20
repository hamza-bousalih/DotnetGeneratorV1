using DotnetGenerator.Zynarator.Dto;

namespace DotnetGenerator.Ws.Dto;

public class AchatDto : BaseDto
{
    public string? Reference { get; set; }
    public DateTime DateAchat { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaye { get; set; }
    public string? Description { get; set; }

    public ClientDto? Client { get; set; }

    public List<AchatItemDto>? AchatItems { get; set; }
}