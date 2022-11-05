using _0_Framework.Domain;
using UserManagement.Domain.RoleAgg;

namespace UserManagement.Domain.UserAgg
{
    public class User : EntityBase
    {
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public string Email { get; private set; }
        public string CardNo { get; private set; }
        public decimal Wallet { get; private set; }
        public long? AccountId { get; private set; }
        public int? Score { get; private set; }
        public long RoleId { get; private set; }
        public Role Role { get; private set; }
        public string ProfilePhoto { get; private set; }

        public User(string fullname, string username, string password, string mobile,
            long roleId, string profilePhoto)
        {
            Fullname = fullname;
            Username = username;
            Password = password;
            Mobile = mobile;
            RoleId = roleId;

            if (roleId == 0)
                RoleId = 2;
            
            ProfilePhoto = profilePhoto;
        }

        public void Edit(string fullname, string username, string mobile,
            long roleId, string profilePhoto)
        {
            Fullname = fullname;
            Username = username;
            Mobile = mobile;
            RoleId = roleId;

            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}
