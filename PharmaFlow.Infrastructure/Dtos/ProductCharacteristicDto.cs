namespace PharmaFlow.Infrastructure.Dtos;

public record ProductCharacteristicDto
{
    public required Guid ID { get; init; }

    public required string Name { get; init; }

    public required string Value { get; init; }
}
