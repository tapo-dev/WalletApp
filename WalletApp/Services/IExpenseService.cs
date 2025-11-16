using WalletApp.Models;

namespace WalletApp.Services;

public interface IExpenseService {
    public Task<List<Expense>> GetAllExpensesAsync();
    public Task AddExpenseAsync(Expense expense);
}