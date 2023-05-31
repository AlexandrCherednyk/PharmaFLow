using Newtonsoft.Json;
using PharmaFlow.Web.Areas.Pharmacist.ViewModels.Chart;
using PharmaFlow.Web.Areas.Pharmacist.ViewModels.Report;

namespace PharmaFlow.Web.Areas.Pharmacist.Controllers;

[Authorize(Roles = "Admin, Manager, Pharmacist")]
public class ChartController : Controller
{
    private readonly IReportRepository _reportRepository;

    public ChartController(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetOutputReportChart()
    {
        try
        {
            string? userEmail = (User.IsInRole("Admin") || User.IsInRole("Manager")) ? null : User.Identity!.Name!;

            List<OutputReportDto> outputReports = await _reportRepository.GetOutputReportListAsync(userEmail);

            List<DataPointViewModel> dataPoints = new();

            foreach(OutputReportDto report in outputReports)
            {
                dataPoints.Add(new DataPointViewModel(report.CreatedOn.ToOADate(), Decimal.ToDouble(report.TotalPrice)));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            List<OutputReportViewModel> response = outputReports.ToOutputReportViewModelList();

            return View("OutputReportChartPanel", response);
        }
        catch (Exception)
        {
            return View("~/Views/Error.cshtml");
        }
    }
}
