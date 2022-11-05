using _0_Framework.Domain;

namespace ShopManagement.Domain.InvoiceAgg
{
    public class InvoiceItem : EntityBase
    {
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public double UnitPrice { get; private set; }
        public int DiscountRate { get; private set; }
        public long OrderId { get; private set; }
        public Invoice Order { get; private set; }

        public InvoiceItem(long productId, int count, double unitPrice, int discountRate)
        {
            ProductId = productId;
            Count = count;
            UnitPrice = unitPrice;
            DiscountRate = discountRate;
        }
    }
}