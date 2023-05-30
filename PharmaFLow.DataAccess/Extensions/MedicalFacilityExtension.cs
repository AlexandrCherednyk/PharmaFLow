namespace PharmaFLow.DataAccess.Extensions;

public static class MedicalFacilityExtension
{
    public static List<MedicalFacilityDto> ToMedicalFacilityDtoList(this List<MedicalFacilityPersistence> medicalFacilityList)
    {
        return medicalFacilityList.ConvertAll(m => m.ToMedicalFacilityDto());
    }

    public static MedicalFacilityDto ToMedicalFacilityDto(this MedicalFacilityPersistence medicalFacility)
    {
        return new()
        {
            ID = medicalFacility.ID,
            Name = medicalFacility.Name,
            Address = medicalFacility.Address,
            Type = medicalFacility.Type!.ToMedicalFacilityTypeDto(),
            Staff = medicalFacility.Staff!.ToMedicalFacilityContactDtoList(),
        };
    }

    public static MedicalFacilityTypeDto ToMedicalFacilityTypeDto(this MedicalFacilityTypePersistence medicalFacilityType)
    {
        return new()
        {
            ID = medicalFacilityType.ID,
            Name = medicalFacilityType.Name,
        };
    }

    public static List<MedicalFacilityContactDto> ToMedicalFacilityContactDtoList(this List<MedicalFacilityContactPersistence> medicalFacilityContactList)
    {
        return medicalFacilityContactList.ConvertAll(mc => mc.ToMedicalFacilityContactDto());
    }

    public static MedicalFacilityContactDto ToMedicalFacilityContactDto(this MedicalFacilityContactPersistence medicalFacilityContact)
    {
        return new()
        {
            ID = medicalFacilityContact.ID,
            Cotnact = medicalFacilityContact.Contact!.ToContactDto(),
            Position = medicalFacilityContact.Position!.ToMedicalFacilityContactPositionDto(),
        };
    }

    public static MedicalFacilityContactPositionDto ToMedicalFacilityContactPositionDto(this MedicalFacilityContactPositionPersistence medicalFacilityContactPosition)
    {
        return new()
        {
            ID = medicalFacilityContactPosition.ID,
            Name = medicalFacilityContactPosition.Name,
        };
    }

    public static ContactDto ToContactDto(this ContactPersistence contact)
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
