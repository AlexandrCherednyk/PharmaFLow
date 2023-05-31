namespace PharmaFLow.DataAccess.Abstracts.IRepositories;

public interface IMedicalFacilityRepository
{
    Task<List<MedicalFacilityDto>> GetMedicalFacilityListAsync();

    Task<MedicalFacilityDto> GetMedicalFacilityByIDAsync(Guid medicalFacilityID);

    Task RemoveMedicalFacilityByID(Guid medicalFacilityID);

    Task RemoveMedicalFacilityContactByID(Guid medicalFacilityID);

    Task CreateMedicalFacilityTypeAsync(string name);

    Task CreateMedicalFacilityContactPositionAsync(string name);

    Task<List<MedicalFacilityContactDto>> GetMedicalFacilityContactListAsync();
}
