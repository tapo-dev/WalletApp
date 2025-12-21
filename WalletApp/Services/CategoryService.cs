using Microsoft.EntityFrameworkCore;
using WalletApp.Data;
using WalletApp.Models;

namespace WalletApp.Services;

public class CategoryService : ICategoryService {
    private readonly AppDbContext _context;
    
    public CategoryService(AppDbContext context) {
        _context = context;
    }

    public async Task<List<Category>> GetCategoriesAsync(int userId) {
        try {
            var categories = await _context.Categories
                .Where(c => c.UserId == userId)
                .Include(c => c.Subcategories)
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

    public async Task RemoveCategoryAsync(Category category) {
        try {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex) {
            Console.WriteLine($"An error has occured during removing a category: {ex.Message}");
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

    public async Task<List<Subcategory>> GetSubcategoriesFromCategoryAsync(int categoryId, int userId) {
        try {
            var subcategories = await _context.Subcategories
                .Where(s => s.UserId == userId)
                .Where(s => s.CategoryId == categoryId)
                .ToListAsync();
            return subcategories;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error getting all the subcategories: {ex.Message}");
            return new List<Subcategory>();
        }
    }

    public async Task RemoveSubcategoryAsync(Subcategory subcategory) {
        try {
            _context.Subcategories.Remove(subcategory);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex) {
            Console.WriteLine($"An error has occured during removing a subcategory: {ex.Message}");
            throw;
        }
    }
}
