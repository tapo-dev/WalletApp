using WalletApp.Models;

namespace WalletApp.Services;

public interface ICategoryService {
    // Categories part
    public Task<List<Category>> GetCategoriesAsync();
    public Task AddCategoryAsync(Category newCategory);
    
    // Subcategories part
    public Task AddSubCategoryAsync(Subcategory subcategory);
    public Task<List<Subcategory>> GetAllSubcategoriesAsync();
}