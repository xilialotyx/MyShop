using _0_Framework.Domain;
namespace ShopManagement.Domain
{
    public class NotifyOnExist : EntityBase
    {
        public long? UserId { get; set; }
        public long? ProductId { get; set; }
    }
}