namespace AccountingManagement.Domain.AccountAgg
{
    public partial class Voucher
    {
        public long DocNo { get; set; }

        public string AccountCode { get; set; }

        public decimal Amount { get; set; }

        public bool IsDebit { get; set; }
        public DateTime VDate { get; set; }

        public long AuthBy { get; set; }
        public long CreateBy { get; set; }
        public bool Confirm { get; set; }
        public string Description { get; set; }
    }
}