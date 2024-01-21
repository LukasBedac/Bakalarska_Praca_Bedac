using Blazored.SessionStorage;
using Blazorise;
using FRI_Quiz_Bakalarska_Praca.Data.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FRI_Quiz_Bakalarska_Praca.Data
{
    public class OwnAuthenticationProvider : AuthenticationStateProvider
    {
        private ISessionStorageService _sessionStorageService;
        private UserManager<User> _userManager;
        public OwnAuthenticationProvider(ISessionStorageService sessionStorage, UserManager<User> userManager)
        {
            _sessionStorageService = sessionStorage;
            _userManager = userManager;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var email = await _sessionStorageService.GetItemAsync<string>("email");
            ClaimsIdentity identity;
            if (email != null)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, await GetUserRole(email)),
                    new Claim(ClaimTypes.Name, await GetUserName(email)),
                }, "apiauth_type") ;                
            } else
            {
                identity = new ClaimsIdentity();
            }

            
            var user = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(user));
        }
        public async Task UserAuthenticated(string email)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, await GetUserRole(email)),
                new Claim(ClaimTypes.Name, await GetUserName(email)),
            }, "apiauth_type");
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void UserLoggedOut()
        {
            _sessionStorageService.RemoveItemAsync("email");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private async Task<string> GetUserRole(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return roles.Count > 0 ? roles[0] : ""; 
            }

            return "";
        }

        private async Task<string> GetUserName(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var name = await _userManager.GetUserNameAsync(user);
                return name;
            }

            return "";
        }
    }
   
}
