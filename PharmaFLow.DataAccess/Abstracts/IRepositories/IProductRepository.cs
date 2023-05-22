using PharmaFLow.DataAccess.Persistences.Products;

namespace PharmaFLow.DataAccess.Abstracts.IRepositories;

public interface IProductRepository
{
    Task<ProductPersistence> GetProductByIDAsync(int ID);
    Task<List<ProductPersistence>> GetProductsRangeAsync(int from, int to, string search);
    Task<long> GetProductsCountAsync();
    Task<int> AddProductAsync(ProductPersistence product);
    Task UpdateProductAsync(ProductPersistence product);
    Task RemoveProductAsync(int ID);
    Task AddCharactericticAsync(ProductCharacteristicPersistence characteristic);
    Task<List<ProductCharacteristicPersistence>> GetCharactericticsAsync(int productID);
}
