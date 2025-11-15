namespace WalletApp.Data;
using Microsoft.EntityFrameworkCore;
using WalletApp.Models;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Subcategory> Subcategories => Set<Subcategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Category>().HasData(
            new Category() { Id = 1, Name = "Food", Color = "#DB3F21"},
            new Category() { Id = 2, Name = "Housing", Color = "#2338C4"},
            new Category() { Id = 3, Name = "Fun", Color = "#23C423"}
        );

        modelBuilder.Entity<Subcategory>().HasData(
            new Subcategory() { Id = 1, CategoryId = 1, Name = "Restaurant"},
            new Subcategory() { Id = 2, CategoryId = 1, Name = "Groceries"},
            new Subcategory() { Id = 3, CategoryId = 2, Name = "Rent"}
        );
    }
}