using PharmaFlow.Web.Areas.Admin.ViewModels;

namespace PharmaFlow.Web.Areas.Admin.Controllers;

[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserList()
    {
        try
        {
            List<UserDto> users = await _userRepository.GetUserListAsync();

            List<UserViewModel> response = users.ToUserViewModelList();

            return View("UserPanel", response);
        }
        catch (Exception)
        {
            return View("~/Views/Error.cshtml");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetDetailedUser(string email)
    {
        try
        {
            string request = email.ToLower().Trim();
            DetailedUserViewModel user = (await _userRepository.GetUserByEmailAsync(request)).ToDetailedUserViewModel();

            return View("Details", user);
        }
        catch (Exception)
        {
            return View("UserPanel");
        }
    }

    [HttpGet]
    public IActionResult CreateUser()
    {
        return View("AddUser");
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(
        [Required]
        DetailedUserViewModel user)
    {
        if (!ModelState.IsValid || user.PasswordForm is null)
        {
            ViewBag.CreateUserErrorMessage = "Невірні дані.";
            return View("AddUser", user);
        }

        try
        {
            SecurePasswordHasher hasher = new();

            string passwordHash = hasher.HashToString(user.PasswordForm!.Password);

            CreateUserRequest request = new()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role.ToUserRoleDto(),
                PasswordHash = user.PasswordForm!.Password,
            };

            await _userRepository.AddUserAsync(request);

            return RedirectToAction("GetUserList", "User", new { area = "Admin" });
        }
        catch (InvalidOperationException)
        {
            ViewBag.CreateUserErrorMessage = "Користувач з таким імейлом вже існує.";
            return View("AddUser", user);
        }
        catch (Exception)
        {
            ViewBag.CreateUserErrorMessage = "Помилка на сервері, спробуйте повторити пізніше.";
            return View("DetaAddUserils", user);
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateUser(DetailedUserViewModel user)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.UpdateUserErrorMessage = "Невірні дані.";
            return View("Details", user);
        }

        try
        {
            UpdateUserRequest request = new()
            {
                ID = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role.ToUserRoleDto(),
            };

            await _userRepository.UpdateUserAsync(request);

            return RedirectToAction("GetUserList", "User", new { area = "Admin" });
        }
        catch (Exception)
        {
            ViewBag.UpdateUserErrorMessage = "Помилка на сервері, спробуйте повторити пізніше.";
            return View("Details", user);
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateUserEmail(
        [Required]
        DetailedUserViewModel user)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.UpdateUserEmailErrorMessage = "Невірна електронна адреса.";
            return View("Details", user);
        }

        try
        {
            await _userRepository.UpdateUserEmailAsync(user.ID, user.Email.Trim().ToLower());

            return View("Details", user);
        }
        catch (InvalidOperationException)
        {
            ViewBag.UpdateUserEmailErrorMessage = "Не знайдено користувача, або користувач з таким імейлом вже існує.";
            return View("Details", user);
        }
        catch (Exception)
        {
            ViewBag.UpdateUserEmailErrorMessage = "Помилка на сервері, спробуйте повторити пізніше.";
            return View("Details", user);
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateUserPassword(
        [Required]
        DetailedUserViewModel user)
    {
        if (!ModelState.IsValid || user.PasswordForm is null)
        {
            ViewBag.UpdateUserPasswordErrorMessage = "Невірний пароль.";
            return View("Details", user);
        }

        try
        {
            SecurePasswordHasher hasher = new();

            string passwordHash = hasher.HashToString(user.PasswordForm!.Password);

            await _userRepository.UpdateUserPasswordAsync(user.ID, passwordHash);

            return View("Details", user);
        }
        catch (InvalidOperationException)
        {
            ViewBag.UpdateUserPasswordErrorMessage = "Користувач не знайден.";
            return View("Details", user);
        }
        catch (Exception)
        {
            ViewBag.UpdateUserPasswordErrorMessage = "Помилка на сервері, спробуйте повторити пізніше.";
            return View("Details", user);
        }
    }

    [HttpGet]
    public async Task<IActionResult> RemoveUser(Guid ID)
    {
        try
        {
            await _userRepository.RemoveUserByIDAsync(ID);

            return RedirectToAction("GetUserList", "User", new { area = "Admin" });
        }
        catch (Exception)
        {
            return RedirectToAction("GetUserList", "User", new { area = "Admin" });
        }
    }
}

