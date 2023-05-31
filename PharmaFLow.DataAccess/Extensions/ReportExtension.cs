namespace PharmaFLow.DataAccess.Extensions;

public static class ReportExtension
{
    public static OutputReportStatePersistence ToOutputReportStatePersistence(this OutputReportStateDto state)
    {
        return state switch
        {
            OutputReportStateDto.Requested => OutputReportStatePersistence.Requested,
            OutputReportStateDto.Confirmed => OutputReportStatePersistence.Confirmed,
            OutputReportStateDto.Removed => OutputReportStatePersistence.Removed,
            _ => throw new ArgumentException($"Invalid {nameof(state)}: {state}", nameof(state)),
        };
    }

    public static List<InputReportDto> ToInputReportDtoList(this List<InputReportPersistence> inputReportList)
    {
        return inputReportList.ConvertAll(ir => ir.ToInputReportDto());
    }

    public static InputReportDto ToInputReportDto(this InputReportPersistence inputReport)
    {
        return new()
        {
            ID = inputReport.ID,
            Product = inputReport.Product!.ToProductrDto(),
            Count = inputReport.Count,
            TotalPrice = inputReport.TotalPrice,
            CreatedOn = inputReport.CreatedOn,
            User = inputReport.User!.ToUserDto(),
        };
    }

    public static List<OutputReportDto> ToOutputReportDtoList(this List<OutputReportPersistence> outputReportList)
    {
        return outputReportList.ConvertAll(or => or.ToOutputReportDto());
    }

    public static OutputReportDto ToOutputReportDto(this OutputReportPersistence outputReport)
    {
        return new()
        {
            ID = outputReport.ID,
            ProductName = outputReport.Product!.Name,
            Count = outputReport.Count,
            TotalPrice = outputReport.TotalPrice,
            CreatedOn = outputReport.CreatedOn,
            UserCreatorEmail = outputReport.UserCreator!.Email,
            StaffTargetID = outputReport.StaffTarget!.ID,
            ConfirmedOn = outputReport.ConfirmedOn,
            UserConfirmatorEmail = outputReport.UserConfirmator?.Email,
        };
    }
}
