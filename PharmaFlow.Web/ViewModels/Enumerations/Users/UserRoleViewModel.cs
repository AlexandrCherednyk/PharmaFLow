namespace PharmaFlow.Web.ViewModels.Enumerations.Users;

public enum UserRoleViewModel
{
    [Display(Name = "Адмін")]
    Admin = 1,

    [Display(Name = "Менеджер")]
    Manager = 2,

    [Display(Name = "Фарм-представник")]
    Pharmacist = 3,
}
