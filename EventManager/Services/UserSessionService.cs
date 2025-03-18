using EventManager.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace EventManager.Services
{
    public class UserSessionService
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private UserModel? _currentUser;

        public UserSessionService(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }


        public UserModel? CurrentUser => _currentUser;

        public async Task SetUserAsync(string name, string email)
        {
            _currentUser = new UserModel { Name = name, Email = email };
            await _sessionStorage.SetAsync("currentUser", _currentUser);
        }
        public void SetCurrentUser(string name, string email)
        {
            _currentUser = new UserModel { Name = name, Email = email };
        }

        public async Task<UserModel?> GetUserAsync()
        {
            if (_currentUser is null)
            {
                var result = await _sessionStorage.GetAsync<UserModel>("currentUser");
                _currentUser = result.Success ? result.Value : null;
            }
            return _currentUser;
        }

        public async Task<bool> IsUserLoggedIn()
        {
            var user = await GetUserAsync();
            return user != null;
        }
    }
}
