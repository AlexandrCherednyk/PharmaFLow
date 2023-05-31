using PharmaFLow.DataAccess.Extensions;

namespace ComputerShop.DataAccess.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly PharmaFlowDbContext _db;

    public ReportRepository(PharmaFlowDbContext db)
    {
        _db = db;
    }

    public async Task CreateInputReportAsync(Guid productID, string userEmail, int count)
    {
        try
        {
            ProductPersistence product = await _db.Products.FirstAsync(p =>
                p.ID == productID
                && p.State == ProductStatePersistence.Active);

            UserPersistence user = await _db.Users.FirstAsync(u =>
                u.Email == userEmail
                && u.State == UserStatePersistence.Active);

            product.Count += count;

            InputReportPersistence inputReport = new()
            {
                ProductID = product.ID,
                UserID = user.ID,
                Count = count,
                CreatedOn = DateTime.Now,
                TotalPrice = product.Price * count,
            };

            _db.InputReports.Add(inputReport);

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

    public async Task CreateOutputReportAsync(Guid productID, Guid staffID, string userEmail, int count, OutputReportStateDto state)
    {
        try
        {
            ProductPersistence product = await _db.Products.FirstAsync(p =>
                p.ID == productID
                && p.State == ProductStatePersistence.Active);

            UserPersistence user = await _db.Users.FirstAsync(u =>
                u.Email == userEmail
                && u.State == UserStatePersistence.Active);

            MedicalFacilityContactPersistence staff = await _db.MedicalFacilityContacts.FirstAsync(s =>
                s.ID == staffID
                && s.State == MedicalFacilityContactStatePersistence.Active);

            OutputReportPersistence outputReport = new()
            {
                ProductID = product.ID,
                UserCreatorID = user.ID,
                StaffTargetID = staff.ID,
                Count = count,
                CreatedOn = DateTime.Now,
                TotalPrice = product.Price * count,
                State = state.ToOutputReportStatePersistence(),
            };

            if (outputReport.State == OutputReportStatePersistence.Confirmed)
            {
                if ((product.Count - count) < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                product.Count -= count;

                outputReport.UserConfirmatorID = user.ID;
                outputReport.ConfirmedOn = DateTime.Now;
            }

            _db.OutputReports.Add(outputReport);

            await _db.SaveChangesAsync();
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (ArgumentOutOfRangeException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<InputReportDto>> GetInputReportListAsync()
    {
        try
        {
            List<InputReportPersistence> inputReports = await _db.InputReports
                .Include(ir => ir.Product)
                    .ThenInclude(p => p!.Type)
                .Include(ir => ir.Product)
                    .ThenInclude(p => p.Manufacturer)
                .Include(ir => ir.User)
                .ToListAsync();

            return inputReports.ToInputReportDtoList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<OutputReportDto>> GetOutputReportRequestListAsync()
    {
        try
        {
            List<OutputReportPersistence> outputReports = await _db.OutputReports
                .Include(or => or.Product)
                    .ThenInclude(or => or!.Type)
                .Include(or => or.Product)
                    .ThenInclude(p => p!.Manufacturer)
                .Include(or => or.StaffTarget)
                .Include(or => or.UserCreator)
                .Where(or => or.State == OutputReportStatePersistence.Requested)
                .ToListAsync();

            return outputReports.ToOutputReportDtoList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task ConfirmOutputReportAsync(Guid reportID, string userEmail)
    {
        try
        {
            UserPersistence user = await _db.Users.FirstAsync(u =>
                u.Email == userEmail
                && u.State == UserStatePersistence.Active);

            OutputReportPersistence outputReport = await _db.OutputReports.FirstAsync(or =>
                or.ID == reportID
                && or.State == OutputReportStatePersistence.Requested);

            ProductPersistence product = await _db.Products.FirstAsync(p =>
                p.ID == outputReport.ProductID
                && p.State == ProductStatePersistence.Active);

            if ((product.Count - outputReport.Count) < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            product.Count -= outputReport.Count;
            outputReport.ConfirmedOn = DateTime.Now;
            outputReport.UserConfirmatorID = user.ID;
            outputReport.State = OutputReportStatePersistence.Confirmed;

            await _db.SaveChangesAsync();
        }
        catch (ArgumentOutOfRangeException)
        {
            throw;
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

    public async Task RemoveOutputReportAsync(Guid reportID)
    {
        try
        {
            OutputReportPersistence outputReport = await _db.OutputReports.FirstAsync(or =>
                or.ID == reportID
                && or.State == OutputReportStatePersistence.Requested);

            outputReport.State = OutputReportStatePersistence.Removed;

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

    public async Task<List<OutputReportDto>> GetOutputReportListAsync(string? userEmail)
    {
        try
        {
            List<OutputReportPersistence> outputReports = await _db.OutputReports
                .Include(or => or.Product)
                    .ThenInclude(or => or!.Type)
                .Include(or => or.Product)
                    .ThenInclude(p => p!.Manufacturer)
                .Include(or => or.StaffTarget)
                .Include(or => or.UserCreator)
                .Where(or =>
                    (userEmail == null || or.UserCreator!.Email == userEmail)
                    && or.State == OutputReportStatePersistence.Confirmed)
                .ToListAsync();

            return outputReports.ToOutputReportDtoList();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
