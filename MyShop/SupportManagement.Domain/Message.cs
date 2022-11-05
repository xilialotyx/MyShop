namespace SupportManagement.Domain
{
    public partial class Message
    {
        public string MessageText { get; set; }
        public bool SeenByUser { get; set; }
        public DateTime? TimeSeenByUser { get; set; }
        public long? ConversationId { get; set; }

        public bool SeenByBUser { get; set; }
        public DateTime? TimeSeenByBUser { get; set; }
        public bool IsSupportReply { get; set; }
    }
}