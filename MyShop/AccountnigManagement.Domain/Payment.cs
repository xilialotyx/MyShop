using _0_Framework.Domain;

namespace AccountingManagement.Domain.PaymentAgg
{
    public class Payment : EntityBase
    {
        public string Authority { get; set; }
        
        public string RefId { get; set; }
        
        public decimal? Amount { get; set; }
        
        public string Description { get; set; }
        
        public string PaymentGate { get; set; }
        
        public DateTime? PaymentDate { get; set; }
        
        public string PersianDate { get; set; }
        
        public long? InvoiceId { get; set; }
    }
}