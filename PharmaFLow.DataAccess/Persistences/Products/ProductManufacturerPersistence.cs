namespace PharmaFLow.DataAccess.Persistences.Products;

public record ProductManufacturerPersistence
{
    public Guid ID { get; set; }

    public required string Name { get; set; }

    public ProductManufacturerStatePersistence State { get; set; } = ProductManufacturerStatePersistence.Active;

    public List<ProductPersistence> Products { get; set; } = new();
}
