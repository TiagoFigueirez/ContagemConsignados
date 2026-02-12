using Microsoft.Identity.Client;

namespace ContagemConsignados.Services.Interface
{
    public interface IAuthService
    {
        Task<AuthenticationResult> LoginAsync();
        Task<bool> IsUserLoggedAsync();
        Task LogoutAsync();
    }
}
