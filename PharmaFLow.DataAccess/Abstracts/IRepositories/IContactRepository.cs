namespace PharmaFLow.DataAccess.Abstracts.IRepositories;

public interface IContactRepository
{
    Task<List<ContactDto>> GetContactListAsync();

    Task AddContactAsync(ContactDto request);

    Task RemoveContactByID(Guid contactID);
}
