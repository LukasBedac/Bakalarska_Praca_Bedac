using Blazored.SessionStorage;
using Blazorise;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace FRI_Quiz_Bakalarska_Praca.Data
{
    public class OwnAuthenticationProvider : AuthenticationStateProvider
    {
        private ISessionStorageService _sessionStorageService;
        public OwnAuthenticationProvider(ISessionStorageService sessionStorage)
        {
            _sessionStorageService = sessionStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var email = await _sessionStorageService.GetItemAsync<string>("email");
            ClaimsIdentity identity;
            if (email != null)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, email),
                }, "apiauth_type");                
            } else
            {
                identity = new ClaimsIdentity();
            }

            
            var user = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(user));
        }
        public void UserAuthenticated(string email)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, email),
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
    }
   
}
