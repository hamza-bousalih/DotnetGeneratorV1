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

    protected override async Task<Achat?> FindByReferenceEntity(Achat t)
    {
        return await Repository.FindByReferenceEntity(t.Reference);
    }

    protected override async Task DeleteAssociatedLists(int id)
    {
        await _achatItemService.DeleteByAchatId(id);
    }
    
    public Task<int> DeleteByClientId(int id) => Repository.DeleteByClientId(id);

    public Task<List<Achat>?> FindByClientId(int id) => Repository.FindByClientId(id);
}