namespace PharmaFlow.Web.Areas.Pharmacist.ViewModels.Report;

public class OutputReportViewModel
{
    public Guid ID { get; set; }

    public required string ProductName { get; set; }

    public required int Count { get; set; }

    public required decimal TotalPrice { get; set; }

    public DateTime CreatedOn { get; set; }

    public required string UserCreatorEmail { get; set; }

    public required Guid StaffTargetID { get; set; }

    public DateTime ConfirmedOn { get; set; }

    public required string UserConfirmatorEmail { get; set; }
}
