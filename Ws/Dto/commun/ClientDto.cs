using DotnetGenerator.Zynarator.Dto;

namespace DotnetGenerator.Ws.Dto;


    public class ClientDto : BaseDto {
        public string? Cin { get; set; }
        public string? Nom { get; set; }
        public string? Tel { get; set; }
        public string? Email { get; set; }
        public string? Adresse { get; set; }
        public string? Description { get; set; }
        public decimal Creance { get; set; }


    }

