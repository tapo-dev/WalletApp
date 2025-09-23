namespace WalletApp.Models;

public class Statistics {
    public float GetTotalCategory(List<Expense> expenses, Category category) {
        throw new NotImplementedException();
    }
    
    public Dictionary<Category, float> GetTotalsByAllCategories(List<Expense> expenses) {
        throw new NotImplementedException();
    }

    public float GetMonthlyTotal(List<Expense> expenses, int month, int year) {
        throw new NotImplementedException();
    }
}