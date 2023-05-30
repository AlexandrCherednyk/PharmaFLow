using PharmaFLow.DataAccess.Extensions;

namespace PharmaFLow.DataAccess.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly PharmaFlowDbContext _db;

    public ContactRepository(PharmaFlowDbContext db)
    {
        _db = db;
    }

    public async Task<List<ContactDto>> GetContactListAsync()
    {
        try
        {
            List<ContactPersistence> contacts = await _db.Contacts
                .Where(m => m.State == ContactStatePersistence.Active)
                .ToListAsync();

            return contacts.ToContactDtoList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task AddContactAsync(ContactDto request)
    {
        try
        {
            ContactPersistence contact = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
            };

            _db.Contacts.Add(contact);

            await _db.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task RemoveContactByID(Guid contactID)
    {
        try
        {
            ContactPersistence contact = await _db.Contacts.FirstAsync(p =>
                p.ID == contactID
                && p.State == ContactStatePersistence.Active);

            contact.State = ContactStatePersistence.Removed;

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
