using WalletApp.Data;
using WalletApp.Models;

namespace WalletApp.Services;

public class ExpenseService {
    private readonly AppDbContext _context;

    public ExpenseService(AppDbContext context)
    {
        _context = context;
    }
    public void CreateExpense(Expense expense) {
        throw new NotImplementedException();
    }
    
    public void EditExpense(Expense expense) {
        throw new NotImplementedException();
    }
    
    public void DeleteExpense(Expense expense) {
        throw new NotImplementedException();
    }

    public void AdjustBalance(float amount) {
        throw new NotImplementedException();
    }

    public void RecalculateBalance(User user) {
        throw new NotImplementedException();
    }
}