using Microsoft.EntityFrameworkCore;
using WalletApp.Data;
using WalletApp.Models;

namespace WalletApp.Services;

public class StatisticsService : IStatisticsService {
    private readonly AppDbContext _context;
    
    
    
    public StatisticsService(AppDbContext context) {
        _context = context;
    }
    
    public async Task<double> GetTotalByMonthAsync(int month, int year) {
        try {
            var expenses = await _context.Expenses
                .Where(expense => expense.DateAdded.Month.Equals(month))
                .Where(expense => expense.DateAdded.Year.Equals(year))
                .SumAsync(expense => expense.Amount);

            return expenses;
        }
        catch (Exception ex) {
            Console.WriteLine($"An error has occured during getting the total by months: {ex.Message}");
            return 0;
        }
    }

    public async Task<Dictionary<string, double>> GetCategoryTotalsAsync(int month, int year) {
        try {
            var expenses = await _context.Expenses
                .Where(expense => expense.DateAdded.Month.Equals(month))
                .Where(expense => expense.DateAdded.Year.Equals(year))
                .GroupBy(expense => expense.Subcategory.Category.Name)
                .Select(g => new { CategoryName = g.Key, TotalAmount = g.Sum(x => x.Amount) })
                .ToDictionaryAsync(key => key.CategoryName, total => total.TotalAmount);

            return expenses;
        }
        catch (Exception ex) {
            Console.WriteLine($"An error has occured during getting the total by categories: {ex.Message}");
            return new Dictionary<string, double>();
        }
    }
}