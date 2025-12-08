using WalletApp.Models;

namespace WalletApp.Services;

public interface IUserService {
    public Task<User?> RegisterUserAsync(string username, string password);
    public Task<User?> LoginUserAsync(string username, string password);
}