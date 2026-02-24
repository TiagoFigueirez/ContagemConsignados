using ContagemConsignados.Mvvm.Model;
using ContagemConsignados.Services.Interface;

namespace ContagemConsignados.Services
{
    public class UserSessionService : IUserSessionService
    {
        public UserSession CurrentUser {  get; private set; }
        public void SetUser(UserSession userSession)
        {
            CurrentUser = userSession;
        }

        public void Clear()
        {
            CurrentUser = null;
        }

       
    }
}
