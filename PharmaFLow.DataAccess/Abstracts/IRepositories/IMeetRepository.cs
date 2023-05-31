namespace PharmaFLow.DataAccess.Abstracts.IRepositories;

public interface IMeetRepository
{
    Task<List<MeetDto>> GetMeetList(string userEmail);

    Task CreateMeetAsync(DateTime start, DateTime end, Guid staffTargetID, string userEmail);

    Task RemoveMeetAsync(Guid meetID);

    Task CompleteMeetAsync(Guid meetID);
}
