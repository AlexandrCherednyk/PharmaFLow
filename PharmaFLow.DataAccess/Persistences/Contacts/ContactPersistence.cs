namespace PharmaFLow.DataAccess.Persistences.Contacts;

public record ContactPersistence
{
    public Guid ID { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required string Phone { get; set; }

    public ContactStatePersistence State { get; set; } = ContactStatePersistence.Active;

    public List<MedicalFacilityContactPersistence> MedicalFacilityContacts { get; set; } = new();
}
