namespace PharmaFLow.DataAccess.Persistences.Reports;

public class OutputReportPersistence
{
    public Guid ID { get; set; }

    public required Guid ProductID { get; set; }

    public ProductPersistence? Product { get; set; }

    public required int Count { get; set; }

    public required decimal TotalPrice { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? ConfirmedOn { get; set; }

    public OutputReportStatePersistence State { get; set; } = OutputReportStatePersistence.Requested;

    // User report creator.
    public required Guid UserCreatorID { get; set; }

    public UserPersistence? UserCreator { get; set; }

    // Staff Targer.
    public required Guid StaffTargetID { get; set; }

    public MedicalFacilityContactPersistence? StaffTarget { get; set; }

    // User that confirmed the report.
    public Guid? UserConfirmatorID { get; set; }

    public UserPersistence? UserConfirmator { get; set; }
}
