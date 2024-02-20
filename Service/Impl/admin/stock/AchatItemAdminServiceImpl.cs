using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Service.Facade;
using DotnetGenerator.Zynarator.Service;
using DotnetGenerator.Dao.Criteria;
using DotnetGenerator.Dao.Specification;
using Lamar;

namespace DotnetGenerator.Service.Impl;

public class AchatItemServiceImpl : Service<AchatItem, AchatItemDao, AchatItemCriteria, AchatItemSpecification>,
    AchatItemService
{
    public async Task<List<AchatItem>?> FindByAchatId(long id) => await Repository.FindByAchatId(id);
    public async Task<int> DeleteByAchatId(long id) => await Repository.DeleteByAchatId(id);


    public AchatItemServiceImpl(IContainer container) : base(container)
    {
    }
}