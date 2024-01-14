namespace DotnetGenerator.Zynarator.Bean;

public class BusinessObject
{
    protected int Id { get; set; }
    protected string? Label { get; set; }

    public BusinessObject()
    {
    }

    public BusinessObject(int id) => Id = id;

    public override string ToString()
    {
        return Id.ToString();
    }
}