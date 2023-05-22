namespace PharmaFLow.DataAccess.Persistences.Reports;

public class OutputReportPersistence
{
    public Guid ID { get; set; }

    public required Guid ProductID { get; set; }

    public ProductPersistence? Product { get; set; }

    public required int Count { get; set; }

    public required decimal TotalPrice { get; set; }

    public DateTime CreatedOn { get; set; }

    public required Guid UserID { get; set; }

    public UserPersistence? User { get; set; }
}
