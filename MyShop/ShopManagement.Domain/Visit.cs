
using _0_Framework.Domain;
namespace ShopManagement.Domain
{
    public class Visit : EntityBase
    {
        public long? UserId { get; set; }

        public long? ProductId { get; set; }
    }
}