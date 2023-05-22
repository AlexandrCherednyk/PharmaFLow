namespace PharmaFlow.Web.Areas.Admin.ViewModels;

public record CreatePasswordViewModel
{
    [Required(ErrorMessage = "Введіть пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Введіть пароль")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Пароль введено неправильно.")]
    public string PasswordConfirm { get; set; } = null!;
}
