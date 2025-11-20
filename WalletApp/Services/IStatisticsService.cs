using WalletApp.Models;

namespace WalletApp.Services;

public interface IStatisticsService {
    public Task<double> GetTotalByMonthAsync(int month, int year, int userId);
    public Task<Dictionary<string, double>> GetCategoryTotalsAsync(int month, int year, int userId);
}