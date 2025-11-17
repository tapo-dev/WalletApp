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

    public async Task AddSubCategoryAsync(Subcategory subcategory) {
        await _context.Subcategories.AddAsync(subcategory);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Subcategory>> GetSubcategoriesFromCategoryAsync(int categoryId) =>
        await _context.Subcategories.Where(subcategory => subcategory.Category.Id == categoryId).ToListAsync();
}