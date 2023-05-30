using PharmaFlow.Web.Areas.Pharmacist.ViewModels.MedicalFacilities;

namespace PharmaFlow.Web.Areas.Pharmacist.Controllers;

[Authorize(Roles = "Admin, Manager, Pharmacist")]
public class MedicalFacilityController : Controller
{
    private readonly IMedicalFacilityRepository _medicalFacilityRepository;

    public MedicalFacilityController(IMedicalFacilityRepository medicalFacilityRepository)
    {
        _medicalFacilityRepository = medicalFacilityRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetMedicalFacilityList()
    {
        try
        {
            List<MedicalFacilityDto> medicalFacilities = await _medicalFacilityRepository.GetMedicalFacilityListAsync();

            List<MedicalFacilityViewModel> response = medicalFacilities.ToMedicalFacilityViewModelList();

            return View("MedicalFacilityPanel", response);
        }
        catch (Exception)
        {
            return View("~/Views/Error.cshtml");
        }
    }


    [HttpGet]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<IActionResult> RemoveMedicalFacilityByID(Guid ID)
    {
        try
        {
            await _medicalFacilityRepository.RemoveMedicalFacilityByID(ID);

            return RedirectToAction("GetMedicalFacilityList", "MedicalFacility", new { area = "Manager" });
        }
        catch (Exception)
        {
            return View("~/Views/Error.cshtml");
        }
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<IActionResult> RemoveMedicalFacilityContactByID(Guid ID)
    {
        try
        {
            await _medicalFacilityRepository.RemoveMedicalFacilityContactByID(ID);

            return RedirectToAction("GetMedicalFacilityList", "MedicalFacility", new { area = "Manager" });
        }
        catch (Exception)
        {
            return View("~/Views/Error.cshtml");
        }
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Manager")]
    public IActionResult GetMedicalFacilityCharacteristicPanel()
    {
        return View("CharacteristicMedicalFacilityPanel", new CreateMedicalFacilityTypeTypeOrContactPositionViewModel());
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<IActionResult> AddMedicalFacilityType(CreateMedicalFacilityTypeTypeOrContactPositionViewModel request)
    {
        if (request.Type is null)
        {
            ViewBag.AddTypeErrorMessage = "Введіть тип закладу.";
            return View("CharacteristicMedicalFacilityPanel", new CreateMedicalFacilityTypeTypeOrContactPositionViewModel());
        }

        try
        {
            await _medicalFacilityRepository.CreateMedicalFacilityTypeAsync(request.Type!.Name.Trim());

            return RedirectToAction("GetMedicalFacilityList", "MedicalFacility", new { area = "Manager" });
        }
        catch (InvalidOperationException)
        {
            ViewBag.AddTypeErrorMessage = "Тип закладу з такою назвою вже існує.";
            return View("CharacteristicMedicalFacilityPanel", new CreateMedicalFacilityTypeTypeOrContactPositionViewModel());
        }
        catch (Exception)
        {
            return View("CharacteristicMedicalFacilityPanel", new CreateMedicalFacilityTypeTypeOrContactPositionViewModel());
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<IActionResult> AddMedicalFacilityContactPosition(CreateMedicalFacilityTypeTypeOrContactPositionViewModel request)
    {
        if (request.Position is null)
        {
            ViewBag.AddPositionErrorMessage = "Введіть посаду працівника.";
            return View("CharacteristicMedicalFacilityPanel", new CreateMedicalFacilityTypeTypeOrContactPositionViewModel());
        }

        try
        {
            await _medicalFacilityRepository.CreateMedicalFacilityContactPositionAsync(request.Position!.Name.Trim());

            return RedirectToAction("GetMedicalFacilityList", "MedicalFacility", new { area = "Manager" });
        }
        catch (InvalidOperationException)
        {
            ViewBag.AddManufacturerErrorMessage = "Виробник продукту з такою назвою вже існує.";
            return View("CharacteristicMedicalFacilityPanel", new CreateMedicalFacilityTypeTypeOrContactPositionViewModel());
        }
        catch (Exception)
        {
            return View("CharacteristicMedicalFacilityPanel", new CreateMedicalFacilityTypeTypeOrContactPositionViewModel());
        }
    }
}
