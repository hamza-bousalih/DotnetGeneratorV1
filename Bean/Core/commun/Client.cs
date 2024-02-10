using DotnetGenerator.Zynarator.Audit;
namespace DotnetGenerator.Bean.Core;


    public class Client:  AuditBusinessObject
    {
        public string? Cin { get; set; }
        public string? Nom { get; set; }
        public string? Tel { get; set; }
        public string? Email { get; set; }
        public string? Adresse { get; set; }
        public string? Description { get; set; }
        public decimal? Creance { get; set; }


    }

