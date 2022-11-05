using _0_Framework.Application;
using System.Collections.Generic;

namespace UserManagement.Application.Contracts.User
{
    public interface IUserApplication
    {
        UserViewModel GetUserBy(long id);
        OperationResult Register(RegisterUser command);
        OperationResult Edit(EditUser command);
        OperationResult ChangePassword(ChangePassword command);
        OperationResult Login(Login command);
        EditUser GetDetails(long id);
        List<UserViewModel> Search(UserSearchModel searchModel);
        void Logout();
        List<UserViewModel> GetUsers();
    }
}
