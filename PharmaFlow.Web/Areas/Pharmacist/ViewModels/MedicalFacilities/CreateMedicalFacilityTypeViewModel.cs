namespace PharmaFlow.Web.Areas.Pharmacist.ViewModels.MedicalFacilities;

public record CreateMedicalFacilityTypeViewModel
{
    [Required(ErrorMessage = "Введіть тип.")]
    [MaxLength(255, ErrorMessage = "Назва типу має бути менше 255 символів.")]
    public string Name { get; set; } = null!;
}
