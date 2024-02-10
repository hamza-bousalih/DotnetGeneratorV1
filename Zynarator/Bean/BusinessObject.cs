namespace DotnetGenerator.Zynarator.Bean;

public abstract class BusinessObject
{
    public long Id { get; set; }

    protected BusinessObject()
    {
    }

    protected BusinessObject(long id) => Id = id;

    public override string ToString()
    {
        return Id.ToString();
    }
}