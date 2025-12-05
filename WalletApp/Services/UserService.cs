using Microsoft.EntityFrameworkCore;
using WalletApp.Data;
using WalletApp.Models;

namespace WalletApp.Services;

public class UserService : IUserService {
    private readonly AppDbContext _context;

    public UserService(AppDbContext context) {
        _context = context;
    }
    
    public async Task<bool> RegisterUserAsync(string username, string password) {
        try {
            if (await _context.Users.AnyAsync(u => u.Name == username)) {
                Console.WriteLine($"There already is a user with this name.");
                return false;
            }

            // Hashing
            var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var hashBytes = sha256.ComputeHash(passwordBytes);
            var hashedPassword = System.Convert.ToBase64String(hashBytes);

            var newUser = new User(username, hashedPassword);
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex) {
            Console.WriteLine($"An error has occured during registering a new user: {ex.Message}");
            throw;
        }
    }

    public async Task<User?> LoginUserAsync(string username, string password) {
        try {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == username);

            if (user == null) {
                Console.WriteLine($"No user found under the username: {username}");
                return null;
            }

            // Hashing
            var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var hashBytes = sha256.ComputeHash(passwordBytes);
            var hashedPassword = System.Convert.ToBase64String(hashBytes);

            if (hashedPassword != user.Password) {
                Console.WriteLine($"Incorrect password");
                return null;
            }

            return user;
        }
        catch (Exception ex) {
            Console.WriteLine($"An error has occured during logging in a user: {ex.Message}");
            throw;
        }
    }
}