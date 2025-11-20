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
        int testUserId = 1;

        modelBuilder.Entity<User>().HasData(
            new User("admin", "admin") { Id = testUserId, Balance = 0}
        );
        
        modelBuilder.Entity<Category>().HasData(
            new Category() { Id = 1, Name = "Food", Color = "#DB3F21", UserId = testUserId},
            new Category() { Id = 2, Name = "Housing", Color = "#2338C4", UserId = testUserId},
            new Category() { Id = 3, Name = "Fun", Color = "#23C423", UserId = testUserId}
        );

        modelBuilder.Entity<Subcategory>().HasData(
            new Subcategory() { Id = 1, CategoryId = 1, Name = "Restaurant", UserId = testUserId},
            new Subcategory() { Id = 2, CategoryId = 1, Name = "Groceries", UserId = testUserId},
            new Subcategory() { Id = 3, CategoryId = 2, Name = "Rent", UserId = testUserId}
        );

        modelBuilder.Entity<Expense>().HasData(
            new Expense() { Amount = 256, DateAdded = DateTime.Now, Id = 1, Name = "Test", SubcategoryId = 1, UserId = testUserId},
            new Expense() { Amount = 512, DateAdded = DateTime.Now, Id = 2, Name = "Test2", SubcategoryId = 1, UserId = testUserId},
            new Expense() { Amount = 128, DateAdded = DateTime.Now, Id = 3, Name = "Test3", SubcategoryId = 3, UserId = testUserId}
        );
    }
}