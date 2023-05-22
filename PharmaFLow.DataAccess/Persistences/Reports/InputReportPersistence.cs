namespace PharmaFLow.DataAccess.Persistences.Reports;

public record InputReportPersistence
{
    public Guid ID { get; set; }

    public required Guid ProductID { get; set; }

    public ProductPersistence? Product { get; set; }

    public required int Count { get; set; }

    public required decimal TotalPrice { get; set; }

    public required DateTime CreatedOn { get; set; }

    public required Guid UserID { get; set; }

    public UserPersistence? User { get; set; }
}
