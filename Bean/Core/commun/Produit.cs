using DotnetGenerator.Zynarator.Audit;
namespace DotnetGenerator.Bean.Core;


    public class Produit:  AuditBusinessObject
    {
        public string? Reference { get; set; }
        public string? Libelle { get; set; }
        public string? Barcode { get; set; }
        public string? Discription { get; set; }
        public decimal? PrixAchatMoyen { get; set; }
        public decimal? Quantite { get; set; }
        public decimal? SeuilAlert { get; set; }


    }

