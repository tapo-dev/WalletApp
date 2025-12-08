using WalletApp.Models;

namespace WalletApp.Services;

public interface ICategoryService {
    // Categories part
    public Task<List<Category>> GetCategoriesAsync(int userId);
    public Task AddCategoryAsync(Category newCategory);
    public Task RemoveCategoryAsync(Category category);
    
    // Subcategories part
    public Task AddSubCategoryAsync(Subcategory subcategory);
    public Task<List<Subcategory>> GetSubcategoriesFromCategoryAsync(int categoryId, int userId);
}