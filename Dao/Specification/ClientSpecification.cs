using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Criteria;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Specification;
using JasperFx.Core;

namespace DotnetGenerator.Dao.Specification;

public class ClientSpecification: AbstractSpecification<Client, AchatCriteria>
{
    public ClientSpecification(AppDbContext context) : base(context.Clients)
    {
    }
    
    protected  override void ConstructPredicates()
    {
        AddPredicateId();
    }
}