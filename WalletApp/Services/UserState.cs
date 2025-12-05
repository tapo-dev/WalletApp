using WalletApp.Models;

namespace WalletApp.Services;

public class UserState {
    public User? CurrentUser { get; private set; }

    public void SetUser(User user) {
        CurrentUser = user;
    }
}