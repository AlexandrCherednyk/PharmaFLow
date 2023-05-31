using PharmaFLow.DataAccess.Extensions;

namespace PharmaFLow.DataAccess.Repositories;

public class MedicalFacilityRepository : IMedicalFacilityRepository
{
    private readonly PharmaFlowDbContext _db;

    public MedicalFacilityRepository(PharmaFlowDbContext db)
    {
        _db = db;
    }

    public async Task<List<MedicalFacilityDto>> GetMedicalFacilityListAsync()
    {
        try
        {
            List<MedicalFacilityPersistence> medicalFacilities = await _db.MedicalFacilities
                .Include(m => m.Type)
                .Include(m => m.Staff.Where(mc => mc.State == MedicalFacilityContactStatePersistence.Active))
                    .ThenInclude(mc => mc.Contact)
                .Include(m => m.Staff.Where(mc => mc.State == MedicalFacilityContactStatePersistence.Active))
                    .ThenInclude(mc => mc.Position)
                .Where(m => m.State == MedicalFacilityStatePersistence.Active)
                .ToListAsync();

            return medicalFacilities.ToMedicalFacilityDtoList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<MedicalFacilityDto> GetMedicalFacilityByIDAsync(Guid medicalFacilityID)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveMedicalFacilityByID(Guid medicalFacilityID)
    {
        try
        {
            MedicalFacilityPersistence medicalFacility = await _db.MedicalFacilities.FirstAsync(p =>
                p.ID == medicalFacilityID
                && p.State == MedicalFacilityStatePersistence.Active);

            medicalFacility.State = MedicalFacilityStatePersistence.Removed;

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

    public async Task RemoveMedicalFacilityContactByID(Guid medicalFacilityContactID)
    {
        try
        {
            MedicalFacilityContactPersistence medicalFacilityContact = await _db.MedicalFacilityContacts.FirstAsync(p =>
                p.ID == medicalFacilityContactID
                && p.State == MedicalFacilityContactStatePersistence.Active);

            medicalFacilityContact.State = MedicalFacilityContactStatePersistence.Removed;

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

    public async Task CreateMedicalFacilityTypeAsync(string name)
    {
        try
        {
            if (await _db.MedicalFacilityTypes.AnyAsync(p =>
                p.Name == name
                && p.State == MedicalFacilityTypeStatePersistence.Active))
            {
                throw new InvalidOperationException();
            }

            MedicalFacilityTypePersistence type = new()
            {
                Name = name,
            };

            _db.MedicalFacilityTypes.Add(type);

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

    public async Task CreateMedicalFacilityContactPositionAsync(string name)
    {
        try
        {
            if (await _db.MedicalFacilityContactPositions.AnyAsync(p =>
                p.Name == name
                && p.State == MedicalFacilityContactPositionStatePersistence.Active))
            {
                throw new InvalidOperationException();
            }

            MedicalFacilityContactPositionPersistence position = new()
            {
                Name = name,
            };

            _db.MedicalFacilityContactPositions.Add(position);

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

    public async Task<List<MedicalFacilityContactDto>> GetMedicalFacilityContactListAsync()
    {
        try
        {
            List<MedicalFacilityContactPersistence> medicalFacilityContacts = await _db.MedicalFacilityContacts
                .Include(mc => mc.MedicalFacility)
                .Include(mc => mc.Contact)
                .Include(mc => mc.Position)
                .Where(m => m.State == MedicalFacilityContactStatePersistence.Active)
                .ToListAsync();

            return medicalFacilityContacts.ToMedicalFacilityContactDtoList();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
