using _0_Framework.Domain;
namespace ShopManagement.Domain
{
    public class Seller : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }

        public long UserId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public bool? Active { get; set; }
        public string CardNo { get; set; }
        public string Shba { get; set; }
    }
}