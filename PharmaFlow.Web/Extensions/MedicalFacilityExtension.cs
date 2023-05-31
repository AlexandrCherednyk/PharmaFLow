using PharmaFlow.Web.Areas.Pharmacist.ViewModels.MedicalFacilities;

namespace PharmaFlow.Web.Extensions;

public static class MedicalFacilityExtension
{
    public static List<MedicalFacilityViewModel> ToMedicalFacilityViewModelList(this List<MedicalFacilityDto> medicalFacilityList)
    {
        return medicalFacilityList.ConvertAll(m => m.ToMedicalFacilityViewModel());
    }

    public static MedicalFacilityViewModel ToMedicalFacilityViewModel(this MedicalFacilityDto medicalFacility)
    {
        return new()
        {
            ID = medicalFacility.ID,
            Name = medicalFacility.Name,
            Address = medicalFacility.Address,
            TypeID = medicalFacility.Type!.ID,
            TypeName = medicalFacility.Type!.Name,
            Staff = medicalFacility.Staff!.ToMedicalFacilityContactViewModelList(),
        };
    }

    public static List<MedicalFacilityContactViewModel> ToMedicalFacilityContactViewModelList(this List<MedicalFacilityContactDto> medicalFacilityContactList)
    {
        return medicalFacilityContactList.ConvertAll(mc => mc.ToMedicalFacilityContactViewModel());
    }

    public static MedicalFacilityContactViewModel ToMedicalFacilityContactViewModel(this MedicalFacilityContactDto medicalFacilityContact)
    {
        return new()
        {
            ID = medicalFacilityContact.ID,
            CotnactID = medicalFacilityContact.Cotnact!.ID,
            FirstName = medicalFacilityContact.Cotnact!.FirstName,
            LastName = medicalFacilityContact.Cotnact!.LastName,
            Email = medicalFacilityContact.Cotnact!.Email,
            Phone = medicalFacilityContact.Cotnact!.Phone,
            PositionID = medicalFacilityContact.Position!.ID,
            PositionName = medicalFacilityContact.Position!.Name,
        };
    }
}
