namespace PharmaFLow.DataAccess.Extensions;

public static class ContactExtension
{
    public static List<ContactDto> ToContactDtoList(this List<ContactPersistence> contactList)
    {
        return contactList.ConvertAll(c => c.ToContactDto());
    }
}
