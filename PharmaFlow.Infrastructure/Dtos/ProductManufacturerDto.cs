namespace PharmaFlow.Infrastructure.Dtos;

public record ProductManufacturerDto
{
    public required Guid ID { get; init; }

    public required string Name { get; init; }
}
