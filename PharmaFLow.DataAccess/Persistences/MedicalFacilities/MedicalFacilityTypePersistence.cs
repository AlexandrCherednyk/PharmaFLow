namespace PharmaFLow.DataAccess.Persistences.MedicalFacilities;

public record MedicalFacilityTypePersistence
{
    public Guid ID { get; set; }

    public required string Name { get; set; }

    public MedicalFacilityTypeStatePersistence State { get; set; } = MedicalFacilityTypeStatePersistence.Active;

    public List<MedicalFacilityPersistence> MedicalFacilities { get; set; } = new();
}
