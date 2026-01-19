namespace WalletApp.Models;

public class Expense {
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Amount { get; set; }
    public DateTime DateAdded { get; set; }
    
    public int SubcategoryId { get; set; }
    public int UserId { get; set; }
    
    public Subcategory Subcategory { get; set; } = default!;
    public User User { get; set; } = default!;
}