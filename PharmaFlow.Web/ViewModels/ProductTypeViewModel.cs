namespace PharmaFlow.Web.ViewModels;

public record ProductTypeViewModel
{
    public required Guid ID { get; init; }

    public required string Name { get; init; }
}
