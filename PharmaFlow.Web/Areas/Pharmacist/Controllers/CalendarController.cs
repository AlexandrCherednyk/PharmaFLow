using PharmaFlow.Web.Areas.Pharmacist.ViewModels.Calendar;
using PharmaFlow.Web.Areas.Pharmacist.ViewModels.MedicalFacilities;

namespace PharmaFlow.Web.Areas.Pharmacist.Controllers;

[Authorize(Roles = "Admin, Manager, Pharmacist")]
public class CalendarController : Controller
{
    private readonly IMeetRepository _meetRepository;
    private readonly IMedicalFacilityRepository _medicalFacilityRepository;

    public CalendarController(
        IMeetRepository meetRepository,
        IMedicalFacilityRepository medicalFacilityRepository)
    {
        _meetRepository = meetRepository;
        _medicalFacilityRepository = medicalFacilityRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCalendar()
    {
        try
        {
            List<MeetDto> meetings = await _meetRepository.GetMeetList(User.Identity!.Name!);

            List<MeetViewModel> response = meetings.ToMeetViewModelList();

            return View("CalendarPanel", response);
        }
        catch(Exception)
        {
            return View("~/Views/Error.cshtml");
        }
    }

    [HttpGet]
    public async Task<IActionResult> CreateMeetPanel()
    {
        try
        {
            List<MedicalFacilityContactViewModel> staff = (await _medicalFacilityRepository.GetMedicalFacilityContactListAsync()).ToMedicalFacilityContactViewModelList();

            ViewBag.Staff = staff;

            return View("CreateMeetPanel");
        }
        catch (Exception)
        {
            return RedirectToAction("GetCalendar", "Calendar", new { area = "Pharmacist" });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateMeet(CreateMeetViewModel request)
    {
        if (!ModelState.IsValid || request.End < request.Start)
        {
            return RedirectToAction("CreateMeetPanel", "Calendar", new { area = "Pharmacist" });
        }

        try
        {
            await _meetRepository.CreateMeetAsync(request.Start, request.End, request.StaffTargetID, User.Identity!.Name!);

            return RedirectToAction("GetCalendar", "Calendar", new { area = "Pharmacist" });
        }
        catch (Exception)
        {
            return RedirectToAction("CreateMeetPanel", "Calendar", new { area = "Pharmacist" });
        }
    }

    [HttpGet]
    public async Task<IActionResult> RemoveMeet(Guid ID)
    {
        try
        {
            await _meetRepository.RemoveMeetAsync(ID);

            return RedirectToAction("GetCalendar", "Calendar", new { area = "Pharmacist" });
        }
        catch (Exception)
        {
            return RedirectToAction("GetCalendar", "Calendar", new { area = "Pharmacist" });
        }
    }

    [HttpGet]
    public async Task<IActionResult> CompleteMeet(Guid ID)
    {
        try
        {
            await _meetRepository.CompleteMeetAsync(ID);

            return RedirectToAction("GetCalendar", "Calendar", new { area = "Pharmacist" });
        }
        catch (Exception)
        {
            return RedirectToAction("GetCalendar", "Calendar", new { area = "Pharmacist" });
        }
    }
}
