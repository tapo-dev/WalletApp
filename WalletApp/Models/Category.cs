namespace WalletApp.Models;

public class Category {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    
    // 1:N relationship between Category and Subcategory
    public List<Subcategory> Subcategories { get; set; }
}