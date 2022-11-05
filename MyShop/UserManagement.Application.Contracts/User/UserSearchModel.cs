namespace UserManagement.Application.Contracts.User
{
    public class UserSearchModel
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public long RoleId { get; set; }
    }
}
