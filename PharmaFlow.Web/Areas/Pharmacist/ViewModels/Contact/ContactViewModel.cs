namespace PharmaFlow.Web.Areas.Pharmacist.ViewModels.Contact;

public record ContactViewModel
{
    public Guid ID { get; set; }

    [Required(ErrorMessage = "Будь ласка, введіть ім'я.")]
    [MaxLength(255, ErrorMessage = "Ім’я має містити менше 255 символів.")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Будь ласка, введіть прізвище.")]
    [MaxLength(255, ErrorMessage = "Прізвище має бути менше 255 символів.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Будь ласка, введіть електронну пошту.")]
    [MaxLength(255, ErrorMessage = "Електронна пошта має бути менше 255 символів.")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Будь ласка, введіть номер телефону.")]
    [MaxLength(15, ErrorMessage = "Номер телефону має бути менше 15 символів.")]
    [Phone]
    public string Phone { get; set; } = null!;
}
