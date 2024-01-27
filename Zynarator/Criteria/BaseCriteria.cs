namespace DotnetGenerator.Zynarator.Criteria;

public abstract class BaseCriteria
{
    public long? Id { get; set; }
    public long? NotId { get; set; }
    public string[]? OrderByAsc { get; set; }
    public string[]? OrderByDesc { get; set; }
    public List<long>? IdsIn { get; set; }
    public List<long>? IdsNotIn { get; set; }
    public bool? Log { get; set; }
    public int MaxResults { get; set; } = 10;
    public int Page { get; set; }
    public string? SortField { get; set; }
    public string? SortOrder { get; set; }
    public string? FilterName { get; set; }
    public string? FilterWord { get; set; }
    public string[]? Includes { get; set; }
    public string[]? Excludes { get; set; }

    private bool _peagable = false;

    public bool Peagable
    {
        get
        {
            _peagable = MaxResults > 0;
            return _peagable;
        }
        set => _peagable = value;
    }
    
    // protected ExportModel exportModel;
}