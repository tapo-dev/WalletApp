namespace WalletApp.Models;

public class Expense {
    public int Id { get; set; }
    public string Name { get; set; }
    public float Amount { get; set; }
    public Subcategory Subcategory { get; set; }
}