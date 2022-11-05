using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using UserManagement.Infrastructure.EFCore;
using ShopManagement.Application.Contracts;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class OrderRepository : RepositoryBase<long, Order>, IOrderRepository
    {
        private readonly ShopContext _context;
        private readonly UserContext _userContext;

        public OrderRepository(ShopContext context, UserContext userContext) : base(context)
        {
            _context = context;
            _userContext = userContext;
        }

        public double GetAmountBy(long id)
        {
            var order = _context.Orders
                .Select(x => new {x.PayAmount, x.Id})
                .FirstOrDefault(x => x.Id == id);
            if (order != null)
                return order.PayAmount;
            return 0;
        }

        public List<OrderItemViewModel> GetItems(long orderId)
        {
            var products = _context.Products.Select(x => new {x.Id, x.Name}).ToList();
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null)
                return new List<OrderItemViewModel>();

            var items = order.Items.Select(x => new OrderItemViewModel
            {
                Id = x.Id,
                Count = x.Count,
                DiscountRate = x.DiscountRate,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice
            }).ToList();

            foreach (var item in items)
            {
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
            }

            return items;
        }

        public List<OrderViewModel> Search(OrderSearchModel searchModel)
        {
            var users = _userContext.Users.Select(x => new {x.Id, x.Fullname}).ToList();
            var query = _context.Orders.Select(x => new OrderViewModel
            {
                Id = x.Id,
                UserId = x.UserId,
                DiscountAmount = x.DiscountAmount,
                IsCanceled = x.IsCanceled,
                IsPaid = x.IsPaid,
                IssueTrackingNo = x.IssueTrackingNo,
                PayAmount = x.PayAmount,
                PaymentMethodId = x.PaymentMethod,
                RefId = x.RefId,
                TotalAmount = x.TotalAmount,
                CreationDate = x.CreationDate.ToFarsi()
            });

            query = query.Where(x => x.IsCanceled == searchModel.IsCanceled);

            if (searchModel.UserId > 0) query = query.Where(x => x.UserId == searchModel.UserId);

            var orders = query.OrderByDescending(x => x.Id).ToList();
            foreach (var order in orders)
            {
                order.UserFullName = users.FirstOrDefault(x => x.Id == order.UserId)?.Fullname;
                order.PaymentMethod = PaymentMethod.GetBy(order.PaymentMethodId).Name;
            }

            return orders;
        }
    }
}