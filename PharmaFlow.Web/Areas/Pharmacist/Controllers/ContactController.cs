using PharmaFlow.Web.Areas.Admin.ViewModels;
using PharmaFlow.Web.Areas.Pharmacist.ViewModels.Contact;

namespace PharmaFlow.Web.Areas.Pharmacist.Controllers;

[Authorize(Roles = "Admin, Manager, Pharmacist")]
public class ContactController : Controller
{
    private readonly IContactRepository _contactRepository;

    public ContactController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetContactList()
    {
        try
        {
            List<ContactDto> contacts = await _contactRepository.GetContactListAsync();

            List<ContactViewModel> response = contacts.ToContactViewModelList();

            return View("ContactPanel", response);
        }
        catch (Exception)
        {
            return View("~/Views/Error.cshtml");
        }
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<IActionResult> RemoveContactByID(Guid ID)
    {
        try
        {
            await _contactRepository.RemoveContactByID(ID);

            return RedirectToAction("GetContactList", "Contact", new { area = "Pharmacist" });
        }
        catch (Exception)
        {
            return View("~/Views/Error.cshtml");
        }
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Manager")]
    public IActionResult CreateContact()
    {
        return View("CreateContactPanel");
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<IActionResult> CreateContact(
        [Required]
        ContactViewModel contact)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.CreateContactErrorMessage = "Невірні дані.";
            return View("CreateContactPanel", contact);
        }

        try
        {
            ContactDto request = new()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Phone = contact.Phone,
            };

            await _contactRepository.AddContactAsync(request);

            return RedirectToAction("GetContactList", "Contact", new { area = "Pharmacist" });
        }
        catch (Exception)
        {
            ViewBag.CreateContactErrorMessage = "Помилка на сервері, спробуйте повторити пізніше.";
            return View("CreateContactPanel", contact);
        }
    }
}
