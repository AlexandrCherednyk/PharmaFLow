using PharmaFlow.Infrastructure.Dtos.Enumerations.Meetings;
using PharmaFlow.Web.Areas.Pharmacist.ViewModels.Calendar;
using PharmaFlow.Web.ViewModels.Enumerations.Meetings;

namespace PharmaFlow.Web.Extensions;

public static class MeetExtension
{
    public static MeetStateViewModel ToMeetStateViewModel(this MeetStateDto state)
    {
        return state switch
        {
            MeetStateDto.Active => MeetStateViewModel.Active,
            MeetStateDto.Completed => MeetStateViewModel.Completed,
            MeetStateDto.Removed => MeetStateViewModel.Removed,
            _ => throw new ArgumentException($"Invalid {nameof(state)}: {state}", nameof(state)),
        };
    }

    public static List<MeetViewModel> ToMeetViewModelList(this List<MeetDto> meetList)
    {
        return meetList.ConvertAll(m => m.ToMeetViewModel());
    }

    public static MeetViewModel ToMeetViewModel(this MeetDto meet)
    {
        return new()
        {
            ID = meet.ID,
            Start = meet.Start,
            End = meet.End,
            State = meet.State.ToMeetStateViewModel(),
            UserEmail = meet.UserEmail,
            StaffTargetFirstName = meet.StaffTargetFirstName,
            StaffTargetLastName = meet.StaffTargetLastName,
            StaffTargetPositionName = meet.StaffTargetPositionName,
            StaffTargetAddress = meet.StaffTargetAddress,
        };
    }
}
