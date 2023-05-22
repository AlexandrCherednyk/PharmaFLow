namespace PharmaFlow.Web.Areas.Identity.ViewModels;

public record LoginModel
{
    [Required(ErrorMessage = "Вкажіть електронну адресу")]
    [EmailAddress]
    [MaxLength(255, ErrorMessage = "Електронна адреса має містити менше 255 символів")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Вкажіть пароль")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
