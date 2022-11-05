using UserManagement.Application.Contracts.User;
using UserManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Users.User
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public UserSearchModel SearchModel;
        public List<UserViewModel> Users;
        public SelectList Roles;

        private readonly IRoleApplication _roleApplication;
        private readonly IUserApplication _userApplication;

        public IndexModel(IUserApplication userApplication, IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
            _userApplication = userApplication;
        }

        public void OnGet(UserSearchModel searchModel)
        {
            Roles = new SelectList(_roleApplication.List(), "Id", "Name");
            Users = _userApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new RegisterUser
            {
                Roles = _roleApplication.List()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(RegisterUser command)
        {
            var result = _userApplication.Register(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var user = _userApplication.GetDetails(id);
            user.Roles = _roleApplication.List();
            return Partial("Edit", user);
        }

        public JsonResult OnPostEdit(EditUser command)
        {
            var result = _userApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetChangePassword(long id)
        {
            var command = new ChangePassword { Id = id };
            return Partial("ChangePassword", command);
        }

        public JsonResult OnPostChangePassword(ChangePassword command)
        {
            var result = _userApplication.ChangePassword(command);
            return new JsonResult(result);
        }
    }
}
