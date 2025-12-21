namespace WalletApp.Models.DTOs;

public class GraphData {
    public string Name { get; set; }
    public double Amount { get; set; }
    
    public GraphData(string name, double amount) {
        Name = name;
        Amount = amount;
    }
}