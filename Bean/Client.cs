namespace DotnetGenerator.Bean;

public class Client
{
    public int Id { get; set; }
    public string Cin { get; set; }
    public string Nom { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
    public decimal Creance { get; set; }
    
    public List<Achat> Achats { get; set; }
}