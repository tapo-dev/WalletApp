using Microsoft.EntityFrameworkCore;
using WalletApp.Data;
using WalletApp.Models;

namespace WalletApp.Services;

public class CategoryService : ICategoryService {
    private readonly AppDbContext _context;
    
    public CategoryService(AppDbContext context) {
        _context = context;
    }

    public async Task<List<Category>> GetCategoriesAsync() =>
        await _context.Categories.Include(c => c.Subcategories).ToListAsync();
    
    public async Task AddCategoryAsync(Category newCategory) {
        await _context.Categories.AddAsync(newCategory);
        await _context.SaveChangesAsync();
    }
}