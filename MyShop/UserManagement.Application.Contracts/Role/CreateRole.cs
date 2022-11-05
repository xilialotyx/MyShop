using System.Collections.Generic;

namespace UserManagement.Application.Contracts.Role
{
    public class CreateRole
    {
        public string Name { get; set; }
        public List<int> Permissions { get; set; }
    }

}
