
using _0_Framework.Domain;
using System;
namespace ShopManagement.Domain
{
    public class ProductSeller : EntityBase
    {

        public long? ProductId { get; set; }

        public long? SellerId { get; set; }



        public decimal? Price { get; set; }

        public Single? Discount { get; set; }

        public int? ExistCount { get; set; }

        public bool? Show { get; set; }

        public int SitePercent { get; set; }

        public int TimeToDeliver { get; set; }

        public int? ProductInStoreId { get; set; }
    }
}