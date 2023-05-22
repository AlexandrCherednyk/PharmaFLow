namespace PharmaFLow.DataAccess.Abstracts.IRepositories;

public interface IProductTypeRepository
{
    Task AddProductType(string name);

    Task<List<ProductTypePersistence>> GetProductTypeList();
}
