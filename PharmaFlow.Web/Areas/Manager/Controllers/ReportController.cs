using PharmaFlow.Web.Areas.Manager.ViewModels.Report;
using PharmaFlow.Web.Areas.Pharmacist.ViewModels.MedicalFacilities;
using PharmaFlow.Web.Areas.Pharmacist.ViewModels.Product;

namespace PharmaFlow.Web.Areas.Manager.Controllers;

[Authorize(Roles = "Admin, Manager")]
public class ReportController : Controller
{
    private readonly IReportRepository _reportRepository;

    public ReportController(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetInputReportList()
    {
        try
        {
            List<InputReportDto> inputReports = await _reportRepository.GetInputReportListAsync();

            List<InputReportViewModel> response = inputReports.ToInputReportViewModelList();

            return View("InputReportPanel", response);
        }
        catch (Exception)
        {
            return View("~/Views/Error.cshtml");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetOutputReportRequestList()
    {
        try
        {
            List<OutputReportDto> outputReports = await _reportRepository.GetOutputReportRequestListAsync();

            List<OutputReportRequestViewModel> response = outputReports.ToOutputReportRequestViewModelList();

            return View("OutputReportRequestPanel", response);
        }
        catch (Exception)
        {
            return View("~/Views/Error.cshtml");
        }
    }

    [HttpGet]
    public async Task<IActionResult> ConfirmOutputReport(Guid ID)
    {
        try
        {
            await _reportRepository.ConfirmOutputReportAsync(ID, User.Identity!.Name!);

            return RedirectToAction("GetOutputReportRequestList", "Report", new { area = "Manager" });
        }
        catch (Exception)
        {
            return RedirectToAction("GetOutputReportRequestList", "Report", new { area = "Manager" });
        }
    }

    [HttpGet]
    public async Task<IActionResult> RemoveOutputReportRequest(Guid ID)
    {
        try
        {
            await _reportRepository.RemoveOutputReportAsync(ID);

            return RedirectToAction("GetOutputReportRequestList", "Report", new { area = "Manager" });
        }
        catch (Exception)
        {
            return RedirectToAction("GetOutputReportRequestList", "Report", new { area = "Manager" });
        }
    }
}
