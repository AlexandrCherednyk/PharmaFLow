namespace PharmaFlow.Web.Areas.Pharmacist.Controllers;

[Authorize(Roles = "Admin, Manager, Pharmacist")]
public class CalendarController : Controller
{
    public CalendarController()
    {
    }

    [HttpGet]
    public IActionResult GetCalendar()
    {
        try
        {
            return View("Calendar");
        }
        catch(Exception)
        {
            return View("~/Views/Error.cshtml");
        }
    }
}
