using Microsoft.Identity.Client;
using System.Linq;
using System.Threading.Tasks;

namespace ContagemConsignados.Services
{
    public class AuthService
    {
        private readonly IPublicClientApplication _pca;

        private readonly string[] _scopes = new[]
        {
            "User.Read",
            "https://analysis.windows.net/powerbi/api/Dataset.Read.All"
        };

        public AuthService()
        {
            _pca = PublicClientApplicationBuilder
                   .Create("cce19d37-a53f-47d7-a4a2-dabfcc63cc73")
                   .WithAuthority(AzureCloudInstance.AzurePublic, "c85fac03-d01a-400d-bab7-926280466fc0")
                   .WithRedirectUri($"cce19d37-a53f-47d7-a4a2-dabfcc63cc73://auth")
                   .Build();
        }

        public async Task<AuthenticationResult> LoginAsync()
        {
            var accounts = await _pca.GetAccountsAsync();
            var firstAccount = accounts.FirstOrDefault();

            try
            {
                return await _pca
                    .AcquireTokenSilent(_scopes, firstAccount)
                    .ExecuteAsync();
            }
            catch
            {
                return await _pca
                            .AcquireTokenInteractive(_scopes)
                            .WithPrompt(Prompt.SelectAccount)
                            .ExecuteAsync();
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
