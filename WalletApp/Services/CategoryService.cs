using Microsoft.EntityFrameworkCore;
using WalletApp.Data;
using WalletApp.Models;

namespace WalletApp.Services;

public class CategoryService : ICategoryService {
    private readonly AppDbContext _context;
    
    public CategoryService(AppDbContext context) {
        _context = context;
    }

    public async Task<List<Category>> GetCategoriesAsync() {
        try {
            var categories = await _context.Categories.Include(c => c.Subcategories)
                .ToListAsync();
            return categories;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error getting all the categories: {ex.Message}");
            return new List<Category>();
        }
    }
    
    public async Task AddCategoryAsync(Category newCategory) {
        try {
            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex) {
            Console.WriteLine($"Error in adding a category: {ex.Message}");
            throw;
        }
    }

    public async Task AddSubCategoryAsync(Subcategory subcategory) {
        try {
            await _context.Subcategories.AddAsync(subcategory);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex) {
            Console.WriteLine($"Error in adding a subcategory: {ex.Message}");
            throw;
        }
    }

    public async Task<List<Subcategory>> GetSubcategoriesFromCategoryAsync(int categoryId) {
        try {
            var subcategories = await _context.Subcategories
                .Where(subcategory => subcategory.Category.Id == categoryId)
                .ToListAsync();
            return subcategories;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error getting all the subcategories: {ex.Message}");
            return new List<Subcategory>();
        }
    }
}
