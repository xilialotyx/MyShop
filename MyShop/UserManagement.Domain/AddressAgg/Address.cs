using _0_Framework.Domain;
namespace UserManagement.Domain.AddressAgg
{
    public class Address : EntityBase
    {
        public long FUserId { get; private set; }
        public string FullName { get;private  set; }
        public string Mobile { get;private set; }
        public long ProvinceId { get;private set; }
        public long CityId { get;private set; }
        public string PostalAddress { get;private set; }
        public string PostalCode { get;private set; }
        public decimal Longi { get;private set; }
        public decimal Lati { get;private set; }
    }

}