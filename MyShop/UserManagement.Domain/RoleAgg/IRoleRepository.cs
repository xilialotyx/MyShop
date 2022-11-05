using _0_Framework.Domain;
using UserManagement.Application.Contracts.Role;
using System.Collections.Generic;

namespace UserManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepository<long, Role>
    {
        List<RoleViewModel> List();
        EditRole GetDetails(long id);
    }
}
