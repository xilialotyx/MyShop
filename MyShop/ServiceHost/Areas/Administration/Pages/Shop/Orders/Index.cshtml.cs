using System.Collections.Generic;
using UserManagement.Application.Contracts.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceHost.Areas.Administration.Pages.Users.Role;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Areas.Administration.Pages.Shop.Orders
{
    public class IndexModel : PageModel
    {
        public OrderSearchModel SearchModel;
        public SelectList Users;
        public List<OrderViewModel> Orders;

        private readonly IOrderApplication _orderApplication;
        private readonly IUserApplication _userApplication;

        public IndexModel(IOrderApplication orderApplication, IUserApplication userApplication)
        {
            _orderApplication = orderApplication;
            _userApplication = userApplication;
        }

        public void OnGet(OrderSearchModel searchModel)
        {
            Users = new SelectList(_userApplication.GetUsers(), "Id", "Fullname");
            Orders = _orderApplication.Search(searchModel);
        }

        public IActionResult OnGetConfirm(long id)
        {
            _orderApplication.PaymentSucceeded(id, 0);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetCancel(long id)
        {
            _orderApplication.Cancel(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetItems(long id)
        {
            var items = _orderApplication.GetItems(id);
            return Partial("Items", items);
        }
    }
}