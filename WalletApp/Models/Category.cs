namespace WalletApp.Models;

public class Category {
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Color { get; set; } = default!;
    
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    
    // 1:N relationship between Category and Subcategory
    public List<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
}