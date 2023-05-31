using PharmaFlow.Infrastructure.Dtos.Enumerations.Meetings;

namespace PharmaFlow.Infrastructure.Dtos;

public record MeetDto
{
    public Guid ID { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public MeetStateDto State { get; set; }

    public required string UserEmail { get; set; }

    public required string StaffTargetFirstName { get; set; }

    public required string StaffTargetLastName { get; set; }

    public required string StaffTargetPositionName { get; set; }

    public required string StaffTargetAddress { get; set; }
}
