namespace DotnetGenerator.Bean;

public class Achat
{
    public int Id { get; set; }
    public string Reference { get; set; }
    public DateTime DateAchat { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaye { get; set; }
    public string Description { get; set; }

    public Client Client { get; set; }
    
    public List<AchatItem> AchatItems { get; set; }
}