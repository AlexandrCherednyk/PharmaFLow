namespace PharmaFLow.DataAccess.Repositories;

public class MeetRepository : IMeetRepository
{
    private readonly PharmaFlowDbContext _db;

    public MeetRepository(PharmaFlowDbContext db)
    {
        _db = db;
    }

    public async Task CreateMeetAsync(DateTime start, DateTime end, Guid staffTargetID, string userEmail)
    {
        try
        {
            UserPersistence user = await _db.Users.FirstAsync(u =>
                u.Email == userEmail
                && u.State == UserStatePersistence.Active);

            bool isCrossTime = await _db.Meetings.AnyAsync(m =>
                m.UserID == user.ID
                && ((start >= m.Start && start < m.End)
                    || (end > m.Start && end <= m.End)));

            if (isCrossTime)
            {
                throw new InvalidOperationException();
            }

            MeetPersistence meet = new()
            {
                Start = start,
                End = end,
                UserID = user.ID,
                StaffTargetID = staffTargetID,
            };

            _db.Meetings.Add(meet);

            await _db.SaveChangesAsync();
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<MeetDto>> GetMeetList(string userEmail)
    {
        try
        {
            UserPersistence user = await _db.Users.FirstAsync(u =>
                u.Email == userEmail
                && u.State == UserStatePersistence.Active);

            DateTime currentDate = DateTime.Now;

            List<MeetPersistence> meetings = await _db.Meetings
                .Include(m => m.User)
                .Include(m => m.StaffTarget)
                    .ThenInclude(s => s!.Contact)
                .Include(m => m.StaffTarget)
                    .ThenInclude(s => s!.MedicalFacility)
                .Include(m => m.StaffTarget)
                    .ThenInclude(s => s!.Position)
                .Where(m =>
                    m.UserID == user.ID
                    && m.Start.Date == currentDate.Date
                    && m.State != MeetStatePersistence.Removed)
                .ToListAsync();

            return meetings.ToMeetDtoList();
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task RemoveMeetAsync(Guid meetID)
    {
        try
        {
            MeetPersistence meet = await _db.Meetings.FirstAsync(u =>
                u.ID == meetID
                && u.State != MeetStatePersistence.Removed);

            meet.State = MeetStatePersistence.Removed;

            await _db.SaveChangesAsync();
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task CompleteMeetAsync(Guid meetID)
    {
        try
        {
            MeetPersistence meet = await _db.Meetings.FirstAsync(u =>
                u.ID == meetID
                && u.State != MeetStatePersistence.Removed);

            meet.State = MeetStatePersistence.Completed;

            await _db.SaveChangesAsync();
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
