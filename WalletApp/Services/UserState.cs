using WalletApp.Models;

namespace WalletApp.Services;

public class UserState {
    public User? CurrentUser { get; private set; }
    
    public event Action? OnChange;
    
    public bool IsLoading { get; private set; } = true;

    public void SetUser(User user) {
        CurrentUser = user;
        NotifyStateChanged();
    }

    public void LogoutUser() {
        CurrentUser = null;
        NotifyStateChanged();
    }
    
    // Helper function for event
    private void NotifyStateChanged() => OnChange?.Invoke();
    
    public void FinishLoading()
    {
        IsLoading = false;
        NotifyStateChanged();
    }
}