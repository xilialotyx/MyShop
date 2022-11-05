namespace SupportManagement.Domain
{
    public partial class Conversation
    {
        public long? FUserId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public long? BUserIdRelated { get; set; }

        public int Score { get; set; }

        public string Comment { get; set; }

        public int SupportMessageStatus { get; set; }
    }
}