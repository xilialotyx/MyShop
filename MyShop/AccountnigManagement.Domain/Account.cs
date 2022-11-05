namespace AccountingManagement.Domain.AccountAgg
{
    public partial class Account
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsCreditor { get; set; }
        public Decimal Balance { get; set; }
    }
}