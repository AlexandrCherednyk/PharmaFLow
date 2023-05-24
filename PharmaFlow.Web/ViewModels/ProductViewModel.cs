namespace PharmaFlow.Web.ViewModels;

public class ProductViewModel
{
    public required Guid ID { get; init; }

    public required string Name { get; init; }

    public required string Description { get; init; }

    public required ProductTypeViewModel Type { get; init; }

    public required ProductManufacturerViewModel Manufacturer { get; init; }

    public required decimal Price { get; init; }

    public required int Count { get; init; }

    public string? PathToFile { get; init; }

    public List<ProductCharacteristicViewModel> Characteristics { get; init; } = new();
}
