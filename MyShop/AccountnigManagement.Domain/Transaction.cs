namespace AccountingManagement.Domain.AccountAgg
{
    public partial class Transaction
    {
        public int SNum { get; set; }
        public long UserId { get; set; }
        public decimal Amount { get; set; }
        public bool IsCreditor { get; set; }
        public DateTime TDate { get; set; }
        public long? AuthBy { get; set; }
        public long CreateBy { get; set; }
        public bool IsConfirm { get; set; }
        public bool IsAddToAccount { get; set; } = true;
        public string Description { get; set; }
    }
}