namespace PharmaFlow.Infrastructure.Dtos;

public record InputReportDto
{
    public Guid ID { get; set; }

    public required ProductDto Product { get; set; }

    public required int Count { get; set; }

    public required decimal TotalPrice { get; set; }

    public required DateTime CreatedOn { get; set; }

    public required UserDto User { get; set; }
}
