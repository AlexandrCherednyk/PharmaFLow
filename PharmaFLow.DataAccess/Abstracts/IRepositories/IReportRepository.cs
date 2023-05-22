using PharmaFLow.DataAccess.Persistences.Reports;

namespace PharmaFLow.DataAccess.Abstracts.IRepositories;

public interface IReportRepository
{
    Task AddSalesAsync(int productID, int count, decimal? totalPrice, int userID);
    Task AddPurchasesAsync(int productID, int count);

    Task<List<OutputReportPersistence>> GetSalesAsync();
    Task<List<InputReportPersistence>> GetPurchasesAsync();
}

