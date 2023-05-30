namespace PharmaFlow.Web.Areas.Pharmacist.ViewModels.Product;

public record CreateProductViewModel
{
    public Guid ID { get; set; }

    public int Count { get; init; }

    public string? PathToFile { get; set; }

    [Required(ErrorMessage = "Будь ласка, введіть назву.")]
    public string Name { get; init; } = null!;

    [Required(ErrorMessage = "Будь ласка, введіть опис.")]
    public string Description { get; init; } = null!;

    [Required(ErrorMessage = "Будь ласка, оберіть тип.")]
    public Guid TypeID { get; init; }

    [Required(ErrorMessage = "Будь ласка, оберіть виробника.")]
    public Guid ManufacturerID { get; init; }

    [Required(ErrorMessage = "Будь ласка, введіть ціну.")]
    [Range(0, double.MaxValue, ErrorMessage = "Ціна не може бути меншою за 0.")]
    public decimal Price { get; init; }

    [Required(ErrorMessage = "Будь ласка, завантажте зображення продукту.")]
    public IFormFile Image { get; set; } = null!;

    public List<ProductCharacteristicViewModel> Characteristics { get; init; } = new();
}
