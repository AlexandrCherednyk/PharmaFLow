using PharmaFlow.Web.Areas.Manager.ViewModels.Report;
using PharmaFlow.Web.Areas.Pharmacist.ViewModels.Report;

namespace PharmaFlow.Web.Extensions;

public static class ReportExtension
{
    public static List<InputReportViewModel> ToInputReportViewModelList(this List<InputReportDto> inputReportList)
    {
        return inputReportList.ConvertAll(ir => ir.ToInputReportViewModel());
    }

    public static InputReportViewModel ToInputReportViewModel(this InputReportDto inputReport)
    {
        return new()
        {
            ID = inputReport.ID,
            ProductName = inputReport.Product!.Name,
            Count = inputReport.Count,
            TotalPrice = inputReport.TotalPrice,
            CreatedOn = inputReport.CreatedOn,
            UserEmail = inputReport.User!.Email,
        };
    }

    public static List<OutputReportRequestViewModel> ToOutputReportRequestViewModelList(this List<OutputReportDto> outputReportList)
    {
        return outputReportList.ConvertAll(or => or.ToInputReportRequestViewModel());
    }

    public static OutputReportRequestViewModel ToInputReportRequestViewModel(this OutputReportDto outputReport)
    {
        return new()
        {
            ID = outputReport.ID,
            ProductName = outputReport.ProductName,
            Count = outputReport.Count,
            TotalPrice = outputReport.TotalPrice,
            CreatedOn = outputReport.CreatedOn,
            UserCreatorEmail = outputReport.UserCreatorEmail,
            StaffTargetID = outputReport.StaffTargetID,
        };
    }

    public static List<OutputReportViewModel> ToOutputReportViewModelList(this List<OutputReportDto> outputReportList)
    {
        return outputReportList.ConvertAll(or => or.ToOutputReportViewModel());
    }

    public static OutputReportViewModel ToOutputReportViewModel(this OutputReportDto outputReport)
    {
        return new()
        {
            ID = outputReport.ID,
            ProductName = outputReport.ProductName,
            Count = outputReport.Count,
            TotalPrice = outputReport.TotalPrice,
            CreatedOn = outputReport.CreatedOn,
            UserCreatorEmail = outputReport.UserCreatorEmail,
            StaffTargetID = outputReport.StaffTargetID,
            ConfirmedOn = outputReport.ConfirmedOn!.Value,
            UserConfirmatorEmail = outputReport.UserConfirmatorEmail!,
        };
    }
}
