using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Order;

namespace ShopManagement.Domain.InvoiceAgg
{
    public interface IInvoiceRepository : IRepository<long, Invoice>
    {
        double GetAmountBy(long id);
        List<OrderItemViewModel> GetItems(long orderId);
        List<OrderViewModel> Search(OrderSearchModel searchModel);
    }
}