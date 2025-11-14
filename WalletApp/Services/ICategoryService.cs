using WalletApp.Models;

namespace WalletApp.Services;

public interface ICategoryService {
    public Task<List<Category>> GetCategoriesAsync();

    public Task AddCategoryAsync(Category newCategory);
}