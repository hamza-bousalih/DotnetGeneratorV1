using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Service;
using DotnetGenerator.Dao.Criteria;

namespace DotnetGenerator.Service.Facade;

public interface ClientService : IService<Client, ClientCriteria>
{
}