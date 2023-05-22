namespace PharmaFLow.DataAccess.Persistences.Products;

public record ProductPersistence
{
    public Guid ID { get; set; }

    [MaxLength(255)]
    public required string Name { get; set; }

    [MaxLength(255)]
    public required string Description { get; set; }

    public required Guid TypeID { get; set; }

    public ProductTypePersistence? Type { get; set; }

    public required Guid ManufacturerID { get; set; }

    public ProductManufacturerPersistence? Manufacturer { get; set; }

    public required decimal Price { get; set; }

    public required int Count { get; set; }

    public string? PathToFile { get; set; }

    public ProductStatePersistence State { get; set; } = ProductStatePersistence.Active;

    public List<ProductCharacteristicPersistence> Characteristics { get; set; } = new();
}
