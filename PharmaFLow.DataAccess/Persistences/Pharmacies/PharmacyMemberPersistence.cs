namespace PharmaFLow.DataAccess.Persistences.Pharmacies;

public record PharmacyMemberPersistence
{
    public Guid ID { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required string Phone { get; set; } 

    public PharmacyMemberStatePersistence State { get; set; } = PharmacyMemberStatePersistence.Active;

    public required Guid PharmacyID { get; set; }

    public PharmacyPersistence? Pharmacy { get; set; }
}
