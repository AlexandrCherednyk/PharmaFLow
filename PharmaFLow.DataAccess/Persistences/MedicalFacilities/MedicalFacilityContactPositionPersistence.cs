namespace PharmaFLow.DataAccess.Persistences.MedicalFacilities;

public record MedicalFacilityContactPositionPersistence
{
    public Guid ID { get; set; }

    public required string Name { get; set; }

    public MedicalFacilityContactPositionStatePersistence State { get; set; } = MedicalFacilityContactPositionStatePersistence.Active;

    public List<MedicalFacilityContactPersistence> Staff { get; set; } = new();
}
