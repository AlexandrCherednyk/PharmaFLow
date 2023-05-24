namespace PharmaFlow.Infrastructure.Dtos;
public record ProductTypeDto
{
    public required Guid ID { get; init; }

    public required string Name { get; init; }
}
