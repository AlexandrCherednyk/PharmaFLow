using PharmaFlow.Infrastructure.Dtos.Requests;

namespace PharmaFLow.DataAccess.Abstracts.IRepositories;

public interface IProductRepository
{
    Task<List<ProductDto>> GetProductListAsync();

    Task<ProductDto> GetProductByIDAsync(Guid productID);

    Task CreateProductAsync(CreateProductRequest product);

    Task UpdateProductAsync(CreateProductRequest product);

    Task RemoveProductByIDAsync(Guid productID);

    Task<List<ProductTypeDto>> GetProductTypeListAsync();

    Task CreateProductTypeAsync(string name);

    Task<List<ProductManufacturerDto>> GetProductManufacturerListAsync();

    Task CreateProductManufacturerAsync(string name);
}
