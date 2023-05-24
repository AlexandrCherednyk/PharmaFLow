namespace PharmaFlow.Web.Areas.Pharmacist.ViewModels.Product;

public class CreateProductManufacturerViewModel
{
    [Required(ErrorMessage = "Введіть тип.")]
    [MaxLength(255, ErrorMessage = "Назва виробника має бути менше 255 символів.")]
    public string Name { get; set; } = null!;
}
