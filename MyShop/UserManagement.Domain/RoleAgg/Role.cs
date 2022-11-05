using _0_Framework.Domain;
using UserManagement.Domain.UserAgg;
using System.Collections.Generic;

namespace UserManagement.Domain.RoleAgg
{
    public class Role : EntityBase
    {
        public string Name { get; private set; }
        public List<Permission> Permissions { get; private set; }
        public List<User> Users { get; private set; }

        protected Role()
        {
        }

        public Role(string name, List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
            Users = new List<User>();
        }

        public void Edit(string name, List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
        }
    }
}