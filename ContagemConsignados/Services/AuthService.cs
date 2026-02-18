using ContagemConsignados.Mvvm.Model;
using ContagemConsignados.Services.Interface;
using Microsoft.Identity.Client;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Platform;


namespace ContagemConsignados.Services
{
    public class AuthService : IAuthService
    {
        private readonly IPublicClientApplication _pca;
       
        private readonly string[] _scopes = new[]
        {
            "User.Read"
        };


        public AuthService()
        {
            _pca = PublicClientApplicationBuilder
                   .Create(MsalModel.ClientId)
                   .WithAuthority(MsalModel.Authority)
                   .WithRedirectUri($"msal{MsalModel.ClientId}://auth")
                   .Build();
        }

        public async Task<AuthenticationResult> LoginAsync()
        {
            var accounts = await _pca.GetAccountsAsync();
            var firstAccount = accounts.FirstOrDefault();

            try
            {
                var result = await _pca
                    .AcquireTokenSilent(_scopes, firstAccount)
                    .ExecuteAsync();

                return result;
            }
            catch (MsalUiRequiredException)
            {
                var result = await _pca
                            .AcquireTokenInteractive(_scopes)
                            .WithParentActivityOrWindow(MsalModel.ParentWindow)
                            .ExecuteAsync();

                return result;
            }
        }

        public async Task<bool> IsUserLoggedAsync()
        {
            var accounts = await _pca.GetAccountsAsync();
            var firstAccount = accounts.FirstOrDefault();

            if(firstAccount == null) 
                return false;

            try
            {
                var result = await _pca
                    .AcquireTokenSilent(_scopes, firstAccount)
                    .ExecuteAsync();

                return result != null;
            }
            catch
            {
                return false;
            }
        }

        public async Task LogoutAsync()
        {
            var accounts = await _pca.GetAccountsAsync();

            foreach(var account in accounts)
            {
                await _pca.RemoveAsync(account);    
            }
        }
    }
}
