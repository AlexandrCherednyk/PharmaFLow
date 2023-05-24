namespace PharmaFlow.Infrastructure.Dtos.Requests;

public record CreateProductRequest
{
    public Guid ID { get; set; }

    public int Count { get; set; }

    public required string Name { get; init; }

    public required string Description { get; init; }

    public required Guid TypeID { get; init; }

    public required Guid ManufacturerID { get; init; }

    public required decimal Price { get; init; }

    public required string PathToFile { get; set; }

    public List<CreateProductCharacteristicRequest> Characteristics { get; init; } = new();
}
