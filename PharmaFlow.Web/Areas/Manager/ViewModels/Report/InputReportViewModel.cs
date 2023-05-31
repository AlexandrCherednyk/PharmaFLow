namespace PharmaFlow.Web.Areas.Manager.ViewModels.Report;

public record InputReportViewModel
{
    public Guid ID { get; set; }

    public string ProductName { get; set; } = null!;

    public required int Count { get; set; }

    public required decimal TotalPrice { get; set; }

    public required DateTime CreatedOn { get; set; }

    public string UserEmail { get; set; } = null!;
}
