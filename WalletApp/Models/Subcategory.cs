namespace WalletApp.Models;

public class Subcategory {
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Foreign key
    public int CategoryId { get; set; }
    
    // 1:N relationship between Category and Subcategory
    public Category Category { get; set; }
}