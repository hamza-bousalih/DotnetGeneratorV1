using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Service.Facade;
using DotnetGenerator.Zynarator.Service;
using Lamar;

namespace DotnetGenerator.Service.Impl;

public class AchatServiceImpl: Service<Achat, AchatDao>, AchatService
{

    private AchatItemService _achatItemService;
    
    public AchatServiceImpl(IContainer container) : base(container)
    {
        _achatItemService = container.GetInstance<AchatItemService>();
    }

    protected override async Task<Achat?> FindByReference(Achat t)
    {
        return await Repository.FindByReferenceEntity(t.Reference);
    }

    protected override async Task DeleteAssociatedLists(long id)
    {
        await _achatItemService.DeleteByAchatId(id);
    }
    
    public Task<int> DeleteByClientId(long id) => Repository.DeleteByClientId(id);

    public Task<List<Achat>?> FindByClientId(long id) => Repository.FindByClientId(id);
}