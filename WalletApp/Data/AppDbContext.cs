namespace WalletApp.Data;
using Microsoft.EntityFrameworkCore;
using WalletApp.Models;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Subcategory> SubCategories => Set<Subcategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Category>().HasData(
            new Category() { Id = 1, Name = "Food", Color = "#DB3F21"},
            new Category() { Id = 2, Name = "Housing", Color = "#2338C4"},
            new Category() { Id = 3, Name = "Fun", Color = "#23C423"}
        );
    }
}