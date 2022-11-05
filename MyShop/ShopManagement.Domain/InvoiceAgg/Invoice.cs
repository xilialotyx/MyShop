using System.Collections.Generic;
using _0_Framework.Domain;
using System;

namespace ShopManagement.Domain.InvoiceAgg
{
    public class Invoice : EntityBase
    {
        public Guid? UNId { get; set; }
        public long UserId { get; private set; }
        public long? AddressId { get; set; }
        public int? PostId { get; set; }
        public int? Status { get; set; }
        public DateTime? TimeToSendFrom { get; set; }
        public DateTime? TimeToSendTo { get; set; }
        public int? PaymentTypeId { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? TotalPost { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? TotalAmount { get; set; }

        public decimal? WalletUse { get; set; }

        public decimal? PayAmount { get; set; }

        public int TotalGrams { get; set; }

        public List<InvoiceItem> Items { get; private set; }

        public Invoice()
        {
            
        }
    }
}