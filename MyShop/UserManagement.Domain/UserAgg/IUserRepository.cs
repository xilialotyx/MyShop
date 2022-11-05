using _0_Framework.Domain;
using UserManagement.Application.Contracts.User;
using System.Collections.Generic;

namespace UserManagement.Domain.UserAgg
{
    public interface IUserRepository : IRepository<long, User>
    {
        User GetBy(string username);
        EditUser GetDetails(long id);
        List<UserViewModel> GetUsers();
        List<UserViewModel> Search(UserSearchModel searchModel);
    }
}
