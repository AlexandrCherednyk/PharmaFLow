namespace PharmaFLow.DataAccess.Abstracts.IRepositories;

public interface IReportRepository
{
    Task CreateInputReportAsync(Guid productID, string userEmail, int count);

    Task CreateOutputReportAsync(Guid productID, Guid staffID, string userEmail, int count, OutputReportStateDto state);

    Task<List<InputReportDto>> GetInputReportListAsync();

    Task<List<OutputReportDto>> GetOutputReportRequestListAsync();

    Task ConfirmOutputReportAsync(Guid reportID, string userEmail);

    Task RemoveOutputReportAsync(Guid reportID);

    Task<List<OutputReportDto>> GetOutputReportListAsync(string? userEmail);
}

