namespace WalletApp.Services;

public interface IStatisticsService {
    public Task<double> GetTotalByMonthAsync(int month, int year);
}