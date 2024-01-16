using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Service.Facade;
using DotnetGenerator.Zynarator.Service;
using Lamar;

namespace DotnetGenerator.Service.Impl;

public class AchatServiceImpl: Service<Achat, AchatDao>, AchatService
{
    public AchatServiceImpl(IContainer container) : base(container)
    {
    }

    public Task<int> DeleteByClientId(int id) => 
        Repository.DeleteByClientId(id);
}