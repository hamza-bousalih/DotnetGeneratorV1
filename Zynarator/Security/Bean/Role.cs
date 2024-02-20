using DotnetGenerator.Zynarator.Audit;
using DotnetGenerator.Zynarator.Bean;
using Microsoft.AspNetCore.Identity;

namespace DotnetGenerator.Zynarator.Security.Bean;

public class Role : IdentityRole<long>, IBusinessObject
{
    public string? Authority
    {
        get => Name;
        set => Name = value;
    }

    public Role()
    {
    }

    public Role(string authority) : base(authority)
    {
    }
}