namespace WalletApp.Models;

public class User {
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Password { get; private set; } = "";
    public float Balance { get; set; }
    public List<Expense> Expenses_list { get; set;} = new();

    
}