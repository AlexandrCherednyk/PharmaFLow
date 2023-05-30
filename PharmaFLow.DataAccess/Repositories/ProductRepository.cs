using PharmaFLow.DataAccess.Extensions;

namespace ComputerShop.DataAccess.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly PharmaFlowDbContext _db;

    public ProductRepository(PharmaFlowDbContext db)
    {
        _db = db;
    }

    public async Task<List<ProductDto>> GetProductListAsync()
    {
        try
        {
            List<ProductPersistence> products = await _db.Products
                .Include(p => p.Type)
                .Include(p => p.Manufacturer)
                .Include(p => p.Characteristics)
                .Where(p => p.State == ProductStatePersistence.Active)
                .ToListAsync();

            return products.ToProductDtoList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<ProductDto> GetProductByIDAsync(Guid productID)
    {
        try
        {
            ProductPersistence product = await _db.Products
                .Include(p => p.Type)
                .Include(p => p.Manufacturer)
                .Include(p => p.Characteristics)
                .FirstAsync(p =>
                    p.ID == productID
                    && p.State == ProductStatePersistence.Active);

            return product.ToProductrDto();
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task CreateProductAsync(CreateProductRequest request)
    {
        try
        {
            ProductPersistence product = new()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Count = 0,
                TypeID = request.TypeID,
                ManufacturerID = request.ManufacturerID,
                PathToFile = request.PathToFile,
                Characteristics = request.Characteristics.ToProductCharacteristicPersistenceList(),
            };

            _db.Products.Add(product);
            await _db.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task UpdateProductAsync(CreateProductRequest request)
    {
        try
        {
            ProductPersistence product = await _db.Products.FirstAsync(p =>
                p.ID == request.ID
                && p.State == ProductStatePersistence.Active);

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Count = request.Count;
            product.TypeID = request.TypeID;
            product.ManufacturerID = request.ManufacturerID;
            product.PathToFile = request.PathToFile;

            await _db.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task RemoveProductByIDAsync(Guid productID)
    {
        try
        {
            ProductPersistence product = await _db.Products.FirstAsync(p =>
                p.ID == productID
                && p.State == ProductStatePersistence.Active);

            product.State = ProductStatePersistence.Removed;

            await _db.SaveChangesAsync();
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<ProductTypeDto>> GetProductTypeListAsync()
    {
        try
        {
            List<ProductTypePersistence> types = await _db.ProductTypes
                .Where(t => t.State == ProductTypeStatePersistence.Active)
                .ToListAsync();

            return types.ToProductTypeDtoList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<ProductManufacturerDto>> GetProductManufacturerListAsync()
    {
        try
        {
            List<ProductManufacturerPersistence> manufacturers = await _db.ProductManufacturers
                .Where(m => m.State == ProductManufacturerStatePersistence.Active)
                .ToListAsync();

            return manufacturers.ToProductrManufacturerDtoList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task CreateProductTypeAsync(string name)
    {
        try
        {
            if (await _db.ProductTypes.AnyAsync(p =>
                p.Name == name
                && p.State == ProductTypeStatePersistence.Active))
            {
                throw new InvalidOperationException();
            }

            ProductTypePersistence productType = new()
            {
                Name = name,
            };

            _db.ProductTypes.Add(productType);

            await _db.SaveChangesAsync();
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task CreateProductManufacturerAsync(string name)
    {
        try
        {
            if (await _db.ProductManufacturers.AnyAsync(p =>
                p.Name == name
                && p.State == ProductManufacturerStatePersistence.Active))
            {
                throw new InvalidOperationException();
            }

            ProductManufacturerPersistence productManufacturer = new()
            {
                Name = name,
            };

            _db.ProductManufacturers.Add(productManufacturer);

            await _db.SaveChangesAsync();
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
