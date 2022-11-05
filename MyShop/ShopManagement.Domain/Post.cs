using _0_Framework.Domain;
namespace ShopManagement.Domain
{
    public class Post : EntityBase
    {
        public string Name { get; set; }
        public int SendDaysInCity { get; set; }

        public int SendDaysInProv { get; set; }

        public int SendDaysInCon { get; set; }

        public bool? Show { get; set; }
    }
}