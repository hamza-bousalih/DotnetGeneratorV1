﻿using DotnetGenerator.Zynarator.Dto;

namespace DotnetGenerator.WS.Dto;

public class ClientDto: BaseDto
{
    public new int Id
    {
        get => base.Id;
        set => base.Id = value;
    }
    public string Cin { get; set; }
    public string Nom { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
    public decimal Creance { get; set; }

    public List<AchatDto> Achats { get; set; }
}