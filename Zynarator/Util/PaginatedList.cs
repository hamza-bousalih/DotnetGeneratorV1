namespace DotnetGenerator.Zynarator.Util;

[Serializable]
public class PaginatedList<T>
{
    public List<T> List { get; set; } = new();

    public int DataSize { get; set; } = 0;
}