namespace PharmaFlow.Web.Areas.Pharmacist.ViewModels.MedicalFacilities;

public record MedicalFacilityViewModel
{
    public Guid ID { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public Guid TypeID { get; set; }

    public string TypeName { get; set; } = null!;

    public List<MedicalFacilityContactViewModel> Staff { get; set; } = new();
}
