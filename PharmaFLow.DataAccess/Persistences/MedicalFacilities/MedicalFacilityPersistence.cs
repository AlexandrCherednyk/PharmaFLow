namespace PharmaFLow.DataAccess.Persistences.MedicalFacilities;

public record MedicalFacilityPersistence
{
    public Guid ID { get; set; }

    public required string Name { get; set; }

    public required string Address { get; set; }

    public Guid TypeID { get; set; }

    public required MedicalFacilityTypePersistence Type { get; set; }

    public MedicalFacilityStatePersistence State { get; set; } = MedicalFacilityStatePersistence.Active;

    public List<MedicalFacilityContactPersistence> Staff { get; set; } = new();
}
