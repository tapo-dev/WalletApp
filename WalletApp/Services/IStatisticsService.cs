using WalletApp.Models;

namespace WalletApp.Services;

public interface IStatisticsService {
    public Task<Dictionary<string, double>> GetCategoryTotalsByDateAsync(DateTime dateTime, int userId);
}