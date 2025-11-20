using WalletApp.Models;

namespace WalletApp.Services;

public interface IStatisticsService {
    public Task<double> GetTotalByMonthAsync(int month, int year);
    public Task<Dictionary<string, double>> GetCategoryTotalsAsync(int month, int year);
}