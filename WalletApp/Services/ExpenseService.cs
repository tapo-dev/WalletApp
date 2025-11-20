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

    public async Task<List<Expense>> GetAllExpensesAsync(int userId) {
        try {
            var expenses = await _context.Expenses
                .Where(e => e.UserId == userId)
                .Include(expense => expense.Subcategory)
                .ToListAsync();
            return expenses;
        }
        catch (Exception ex){
            Console.WriteLine($"Error getting all the expenses: {ex.Message}");
            return new List<Expense>();
        }
    }
        
    public async Task AddExpenseAsync(Expense expense) {
        try {
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex){
            Console.WriteLine($"Error adding an expense: {ex.Message}");
            throw;
        }
    }
}