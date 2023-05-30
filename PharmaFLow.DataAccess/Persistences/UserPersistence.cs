namespace PharmaFLow.DataAccess.Persistences;

public record UserPersistence
{
    public Guid ID { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required UserRolePersistence Role { get; set; } = UserRolePersistence.Pharmacist;

    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public UserStatePersistence State { get; set; } = UserStatePersistence.Active;

    // Sales reports.
    public List<InputReportPersistence> InputReports { get; set; } = new();
}
