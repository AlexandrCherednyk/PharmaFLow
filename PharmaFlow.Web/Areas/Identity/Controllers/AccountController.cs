namespace PharmaFlow.Web.Areas.Identity.Controllers;

[AllowAnonymous]
public class AccountController : Controller
{
    private readonly IUserRepository _userRepository;

    public AccountController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Невірна адреса електронної пошти та (або) пароль.");
            return View(loginModel);
        }

        try
        {
            string request = loginModel.Email.ToLower().Trim();
            UserViewModel user = (await _userRepository.GetUserByEmailAsync(request)).ToUserViewModel();

            SecurePasswordHasher hasher = new();

            if (hasher.Verify(loginModel.Password, user.PasswordHash))
            {
                await Authenticate(user);

                return RedirectToAction("GetCalendar", "Calendar", new { area = "Pharmacist" });
            }
            
            ModelState.AddModelError("", "Невірна адреса електронної пошти та (або) пароль.");
            return View(loginModel);
        }
        catch (Exception)
        {
            ModelState.AddModelError("", "Вибачте, відбулася помилка на сервері. Будь ласка, спробуйте ще раз пізніше або зв'яжіться з адміністратором.");
            return View(loginModel);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Login", "Account");
    }

    private async Task Authenticate(UserViewModel user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, Enum.GetName(typeof(UserRoleViewModel), user.Role)!),
        };

        ClaimsIdentity id = new(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme,
            ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }
}
