namespace WalletApp.Models;

public class User {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public float Balance { get; set; }
    public List<Expense> Expenses { get; set;} = new List<Expense>();
    public List<Category> Categories { get; set; } = new List<Category>();
    public List<Subcategory> Subcategories { get; set; } = new List<Subcategory>();

    // For EF
    public User() { }

    public User(string name, string password) {
        Name = name;
        Password = password;
    }
}