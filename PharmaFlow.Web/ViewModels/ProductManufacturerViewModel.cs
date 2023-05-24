namespace PharmaFlow.Web.ViewModels;

public record ProductManufacturerViewModel
{
    public required Guid ID { get; init; }

    public required string Name { get; init; }
}
