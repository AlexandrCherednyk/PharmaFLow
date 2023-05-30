using PharmaFlow.Web.Areas.Pharmacist.ViewModels.Contact;

namespace PharmaFlow.Web.Extensions;

public static class ContactExtension
{
    public static List<ContactViewModel> ToContactViewModelList(this List<ContactDto> contactList)
    {
        return contactList.ConvertAll(m => m.ToContactViewModel());
    }

    public static ContactViewModel ToContactViewModel(this ContactDto contact)
    {
        return new()
        {
            ID = contact.ID,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Email = contact.Email,
            Phone = contact.Phone,
        };
    }
}
