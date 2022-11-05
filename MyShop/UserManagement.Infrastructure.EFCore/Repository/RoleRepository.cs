using _0_Framework.Application;
using _0_Framework.Infrastructure;
using UserManagement.Application.Contracts.Role;
using UserManagement.Domain.RoleAgg;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace UserManagement.Infrastructure.EFCore.Repository
{
    public class RoleRepository : RepositoryBase<long, Role>, IRoleRepository
    {
        private readonly UserContext _userContext;

        public RoleRepository(UserContext userContext) : base(userContext)
        {
            _userContext = userContext;
        }

        public EditRole GetDetails(long id)
        {
            var role = _userContext.Roles.Select(x => new EditRole
                {
                    Id = x.Id,
                    Name = x.Name,
                    MappedPermissions = MapPermissions(x.Permissions)
                }).AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            role.Permissions = role.MappedPermissions.Select(x => x.Code).ToList();

            return role;
        }

        private static List<PermissionDto> MapPermissions(IEnumerable<Permission> permissions)
        {
            return permissions.Select(x => new PermissionDto(x.Code, x.Name)).ToList();
        }

        public List<RoleViewModel> List()
        {
            return _userContext.Roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi()
            }).ToList();
        }
    }
}