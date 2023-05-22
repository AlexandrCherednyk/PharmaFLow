namespace PharmaFLow.DataAccess.Persistences.Products;

public record ProductTypePersistence
{
    public Guid ID { get; set; }

    public required string Name { get; set; }

    public ProductTypeStatePersistence State { get; set; } = ProductTypeStatePersistence.Active;

    public List<ProductPersistence> Products { get; set; } = new();
}
