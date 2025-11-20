namespace WalletApp.Models;

public class Subcategory {
    public int Id { get; set; }
    public string Name { get; set; }

    public int CategoryId { get; set; }
    public int UserId { get; set; }

    public Category Category { get; set; } = default!;
    public User User { get; set; } = default!;
    
    public List<Expense> Expenses { get; set; } = new List<Expense>();
}