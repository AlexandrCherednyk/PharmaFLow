namespace PharmaFLow.DataAccess.Extensions;

public static class MeetExtension
{
    public static MeetStateDto ToMeetStateDto(this MeetStatePersistence state)
    {
        return state switch
        {
            MeetStatePersistence.Active => MeetStateDto.Active,
            MeetStatePersistence.Completed => MeetStateDto.Completed,
            MeetStatePersistence.Removed => MeetStateDto.Removed,
            _ => throw new ArgumentException($"Invalid {nameof(state)}: {state}", nameof(state)),
        };
    }

    public static List<MeetDto> ToMeetDtoList(this List<MeetPersistence> meetList)
    {
        return meetList.ConvertAll(m => m.ToMeetDto());
    }

    public static MeetDto ToMeetDto(this MeetPersistence meet)
    {
        return new()
        {
            ID = meet.ID,
            Start = meet.Start,
            End = meet.End,
            State = meet.State.ToMeetStateDto(),
            UserEmail = meet.User!.Email,
            StaffTargetFirstName = meet.StaffTarget!.Contact!.FirstName,
            StaffTargetLastName = meet.StaffTarget!.Contact!.LastName,
            StaffTargetPositionName = meet.StaffTarget!.Position!.Name,
            StaffTargetAddress = meet.StaffTarget!.MedicalFacility!.Address,
        };
    }
}
