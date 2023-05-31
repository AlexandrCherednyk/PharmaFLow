namespace PharmaFLow.DataAccess.Persistences.Meetings;

public class MeetPersistence
{
    public Guid ID { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public MeetStatePersistence State { get; set; } = MeetStatePersistence.Active;

    public required Guid UserID { get; set; }

    public UserPersistence? User { get; set; }

    public required Guid StaffTargetID { get; set; }

    public MedicalFacilityContactPersistence? StaffTarget { get; set; }
}
