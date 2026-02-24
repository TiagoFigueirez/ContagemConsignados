using ContagemConsignados.Mvvm.Model;

namespace ContagemConsignados.Services.Interface
{
    public interface IUserSessionService
    {
        UserSession CurrentUser { get; }   
        void SetUser(UserSession userSession);
        void Clear();
    }
}
