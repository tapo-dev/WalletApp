using Microsoft.EntityFrameworkCore;
using WalletApp.Data;
using WalletApp.Models;

namespace WalletApp.Services;

public class ExpenseService : IExpenseService {
    private readonly AppDbContext _context;
    public ExpenseService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Expense>> GetAllExpensesAsync() => 
        await _context.Expenses.Include(expense => expense.Subcategory).ToListAsync();
    public async Task AddExpenseAsync(Expense expense) {
        await _context.Expenses.AddAsync(expense);
        await _context.SaveChangesAsync();
    }
}