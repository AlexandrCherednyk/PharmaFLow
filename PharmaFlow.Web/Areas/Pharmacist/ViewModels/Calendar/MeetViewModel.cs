using PharmaFlow.Web.ViewModels.Enumerations.Meetings;

namespace PharmaFlow.Web.Areas.Pharmacist.ViewModels.Calendar;

public record MeetViewModel
{
    public Guid ID { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public MeetStateViewModel State { get; set; }

    public required string UserEmail { get; set; }

    public required string StaffTargetFirstName { get; set; }

    public required string StaffTargetLastName { get; set; }

    public required string StaffTargetPositionName { get; set; }

    public required string StaffTargetAddress { get; set; }
}
