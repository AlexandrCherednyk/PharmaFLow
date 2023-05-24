namespace PharmaFlow.Infrastructure.Dtos.Requests;

public record CreateProductCharacteristicRequest
{
    public required string Name { get ; init; }

    public required string Value { get ; init; }
}
