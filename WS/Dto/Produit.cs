﻿using DotnetGenerator.Zynarator.Audit;
using DotnetGenerator.Zynarator.Dto;

namespace DotnetGenerator.WS.Dto;

public class ProduitDto: BaseDto
{
    public new int Id
    {
        get => base.Id;
        set => base.Id = value;
    }
    public string Reference { get; set; }
    public string Libelle { get; set; }
    public string Barcode { get; set; }
    public string Discription { get; set; }
    public decimal PrixAchatMoyen { get; set; }
    public decimal Quantite { get; set; }
    public decimal SeuilAlert { get; set; }

    public List<AchatItemDto> AchatItems { get; set; }
}