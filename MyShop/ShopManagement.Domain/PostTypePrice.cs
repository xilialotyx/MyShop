
using _0_Framework.Domain;
namespace ShopManagement.Domain
{
    public class PostTypePrice : EntityBase
    {
        public int? PostId { get; set; }

        public int? PostType { get; set; }

        public int? TillGramsFrom { get; set; }

        public int? TillGramsTo { get; set; }

        public decimal? Price { get; set; }
    }
}