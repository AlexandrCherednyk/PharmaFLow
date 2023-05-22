namespace PharmaFlow.Web.Areas.Admin.ViewModels;

public record DetailedUserViewModel
{
    public Guid ID { get; set; }

    [Required(ErrorMessage = "Будь ласка, введіть ім'я.")]
    [MaxLength(255, ErrorMessage = "Ім’я має містити менше 255 символів.")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Будь ласка, введіть прізвище.")]
    [MaxLength(255, ErrorMessage = "Прізвище має бути менше 255 символів.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Будь ласка, введіть електронну пошту.")]
    [MaxLength(255, ErrorMessage = "електронна пошта має бути менше 255 символів.")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    public UserRoleViewModel Role { get; set; }

    public CreatePasswordViewModel? PasswordForm { get; set; }
}
