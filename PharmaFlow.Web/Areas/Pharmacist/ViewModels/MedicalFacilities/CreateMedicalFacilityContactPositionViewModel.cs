namespace PharmaFlow.Web.Areas.Pharmacist.ViewModels.MedicalFacilities;

public class CreateMedicalFacilityContactPositionViewModel
{
    [Required(ErrorMessage = "Введіть тип.")]
    [MaxLength(255, ErrorMessage = "Назва посади має бути менше 255 символів.")]
    public string Name { get; set; } = null!;
}
