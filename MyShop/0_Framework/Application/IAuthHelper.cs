using System.Collections.Generic;

namespace _0_Framework.Application
{
    public interface IAuthHelper
    {
        void SignOut();
        bool IsAuthenticated();
        void Signin(AuthViewModel user);
        string CurrentUserRole();
        AuthViewModel CurrentUserInfo();
        List<int> GetPermissions();
        long CurrentUserId();
        string CurrentUserMobile();
    }
}
