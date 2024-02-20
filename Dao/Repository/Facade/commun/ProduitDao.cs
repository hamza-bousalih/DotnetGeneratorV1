using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Repository;

namespace DotnetGenerator.Dao.Facade;

public interface ProduitDao : IRepository<Produit>
{
    Task<Produit?> FindByReference(string reference);
    Task<int> DeleteByReference(string reference);
}