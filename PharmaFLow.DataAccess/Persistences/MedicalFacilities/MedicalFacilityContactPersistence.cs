namespace PharmaFLow.DataAccess.Persistences.MedicalFacilities;

public record MedicalFacilityContactPersistence
{
    public Guid ID { get; set; }

    public Guid MedicalFacilityID { get; set; }

    public MedicalFacilityPersistence? MedicalFacility { get; set; }

    public Guid ContactID { get; set; }

    public ContactPersistence? Contact { get; set; }

    public Guid PositionID { get; set; }

    public MedicalFacilityContactPositionPersistence? Position { get; set; }

    public MedicalFacilityContactStatePersistence State { get; set; } = MedicalFacilityContactStatePersistence.Active;
}
