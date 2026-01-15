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

    public async Task DeleteExpenseAsync(int expenseId) {
        try {
            var expense = await _context.Expenses.FindAsync(expenseId);
            if (expense != null) {
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }
            else {
                throw new MissingMemberException();
            }
        }
        catch (Exception ex){
            Console.WriteLine($"An error has occured during deleting an expense: {ex.Message}");
            throw;
        }
    }

    public async Task<Expense?> GetExpenseByIdAsync(int id) {
        try {
            var expense = await _context.Expenses.FindAsync(id);
            return expense;
        }
        catch (Exception ex) {
            Console.WriteLine($"An error has occured during getting an expense by id: {ex.Message}");
            return null;
        }
    }
    public async Task UpdateExpenseAsync(Expense expense) {
        try {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex) {
            Console.WriteLine($"Error updating expense: {ex.Message}");
            throw;
        }
    }
}