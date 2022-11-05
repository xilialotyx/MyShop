using _0_Framework.Domain;
namespace UserManagement.Domain.AddressAgg
{
    public class City : EntityBase
    {
        public long ProvinceId { get; set; }
        public string Name { get; set; }
    }

}