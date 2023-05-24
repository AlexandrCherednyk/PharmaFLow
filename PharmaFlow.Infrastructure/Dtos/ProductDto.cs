namespace PharmaFlow.Infrastructure.Dtos;

public class ProductDto
{
    public required Guid ID { get; init; }

    public required string Name { get; init; }

    public required string Description { get; init; }

    public required ProductTypeDto Type { get; init; }

    public required ProductManufacturerDto Manufacturer { get; init; }

    public required decimal Price { get; init; }

    public required int Count { get; init; }

    public string? PathToFile { get; init; }

    public List<ProductCharacteristicDto> Characteristics { get; init; } = new();
}
