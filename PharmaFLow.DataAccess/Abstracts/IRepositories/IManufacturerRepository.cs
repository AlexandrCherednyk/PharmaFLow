namespace PharmaFLow.DataAccess.Abstracts.IRepositories;

public interface IManufacturerRepository
{
    Task AddManufacturer(string name);
    Task<List<ProductManufacturerPersistence>> GetManufacturerList();
}
