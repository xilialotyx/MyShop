namespace ShopManagement.Application.Contracts.Order
{
    public class OrderSearchModel
    {
        public long UserId { get; set; }
        public bool IsCanceled { get; set; }
    }
}