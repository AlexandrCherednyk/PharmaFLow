namespace PharmaFLow.DataAccess.Persistences.Products;

public record ProductPersistence
{
    public Guid ID { get; set; }

    [MaxLength(255)]
    public string Name { get; set; }

    [MaxLength(255)]
    public string Description { get; set; }

    public Guid TypeID { get; set; }

    public ProductTypePersistence? Type { get; set; }

    public Guid ManufacturerID { get; set; }

    public ProductManufacturerPersistence? Manufacturer { get; set; }

    public decimal Price { get; set; }

    public int Count { get; set; }

    public string? PathToFile { get; set; }

    public ProductStatePersistence State { get; set; } = ProductStatePersistence.Active;

    public List<ProductCharacteristicPersistence> Characteristics { get; set; } = new();
}
