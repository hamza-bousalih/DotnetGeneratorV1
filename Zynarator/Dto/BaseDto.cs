namespace DotnetGenerator.Zynarator.Dto;

public abstract class BaseDto
{
    public int Id { get; set; }
    public string? Label { get; set; }

    protected BaseDto()
    {
    }

    protected BaseDto(int id) => Id = id;

    public override string ToString()
    {
        return Id.ToString();
    }
}