namespace PharmaFLow.DataAccess.Persistences.Products;

public record ProductCharacteristicPersistence
{
    public Guid ID { get; set; }

    public required string Name { get; set; }

    public required string Value { get; set; }

    public ProductCharacteristicStatePersistence State { get; set; } = ProductCharacteristicStatePersistence.Active;

    public List<ProductPersistence> Products { get; set; } = new();
}
