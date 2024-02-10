using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Repository;

namespace DotnetGenerator.Dao.Facade;

public interface ProduitDao : IRepository<Produit> {

    Task<Produit?> FindByReference(String reference);
    Task<int>  DeleteByReference(String reference);




}
