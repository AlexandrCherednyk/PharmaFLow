namespace PharmaFlow.Web.ViewModels;

public record ProductCharacteristicViewModel
{
    public required Guid ID { get; init; }

    public required string Name { get; init; }

    public required string Value { get; init; }
}
