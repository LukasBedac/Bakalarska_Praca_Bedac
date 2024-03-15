using Microsoft.AspNetCore.Components.Authorization;

namespace FRI_Quiz_Bakalarska_Praca.Data
{
    public class AuthStateHelper
    {
        public async Task<string> AuthState(AuthenticationStateProvider authProvider)
        {
            var authState = authProvider.GetAuthenticationStateAsync();
            return null;
        }
    }
}
