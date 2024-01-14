namespace DotnetGenerator.Zynarator.Bean;

public abstract class BusinessObject
{
    public int Id { get; set; }
    public string? Label { get; set; }

    protected BusinessObject()
    {
    }

    protected BusinessObject(int id) => Id = id;

    public override string ToString()
    {
        return Id.ToString();
    }
}