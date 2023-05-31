using PharmaFlow.Web.Areas.Pharmacist.ViewModels.Product;
using PharmaFlow.Web.Areas.Pharmacist.ViewModels.Report;

namespace PharmaFlow.Web.Areas.Pharmacist.Controllers;

[Authorize(Roles = "Admin, Manager, Pharmacist")]
public class ReportController : Controller
{
    private readonly IReportRepository _reportRepository;

    public ReportController(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<IActionResult> CreateInputReport(
        [Required]
        Guid productID,
        [Required(ErrorMessage = "Введіть кількість.")]
        [Range(1, int.MaxValue, ErrorMessage = "Кількість не може бути менше ніж 1")]
        int count)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.CreateInputReportErrorMessage = "Невірні дані.";
            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }

        try
        {
            string userID = User.Identity!.Name!;

            await _reportRepository.CreateInputReportAsync(productID, userID, count);

            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }
        catch (Exception)
        {
            ViewBag.CreateInputReportErrorMessage = "Помилка на сервері, спробуйте повторити пізніше.";
            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateOutputReportRequest(
        CreateProductViewModel
        product,
        [Required]
        Guid productID,
        [Required(ErrorMessage = "Введіть кількість.")]
        [Range(1, int.MaxValue, ErrorMessage = "Кількість не може бути менше ніж 1")]
        int count)
    {
        if (!product.StaffID.HasValue && count <= 0)
        {
            ViewBag.CreateOutputReportRequestErrorMessage = "Невірні дані.";
            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }

        try
        {
            string userID = User.Identity!.Name!;

            await _reportRepository.CreateOutputReportAsync(productID, product.StaffID!.Value, userID, count, OutputReportStateDto.Requested);

            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }
        catch (ArgumentOutOfRangeException)
        {
            ViewBag.CreateOutputReportRequestErrorMessage = "Кількість не може перевищувати кількість на складі.";
            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }
        catch (Exception)
        {
            ViewBag.CreateOutputReportRequestErrorMessage = "Помилка на сервері, спробуйте повторити пізніше.";
            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<IActionResult> CreateOutputReportConfirmed(
        CreateProductViewModel
        product,
        [Required]
        Guid productID,
        [Required(ErrorMessage = "Введіть кількість.")]
        [Range(1, int.MaxValue, ErrorMessage = "Кількість не може бути менше ніж 1")]
        int count)
    {
        if (!product.StaffID.HasValue && count <= 0)
        {
            ViewBag.CreateOutputReportRequestErrorMessage = "Невірні дані.";
            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }

        try
        {
            string userID = User.Identity!.Name!;

            await _reportRepository.CreateOutputReportAsync(productID, product.StaffID!.Value, userID, count, OutputReportStateDto.Confirmed);

            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }
        catch (ArgumentOutOfRangeException)
        {
            ViewBag.CreateOutputReportRequestErrorMessage = "Кількість не може перевищувати кількість на складі.";
            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }
        catch (Exception)
        {
            ViewBag.CreateOutputReportRequestErrorMessage = "Помилка на сервері, спробуйте повторити пізніше.";
            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }
    }
}
