using UserManagement.Application.Contracts.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ServiceHost.Pages
{
    public class UserModel : PageModel
    {
        [TempData]
        public string LoginMessage { get; set; }

        [TempData]
        public string RegisterMessage { get; set; }


        private readonly IUserApplication _userApplication;

        public UserModel(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(Login command)
        {
            var result = _userApplication.Login(command);
            if (result.IsSuccedded)
                return RedirectToPage("/Index");

            LoginMessage = result.Message;
            return RedirectToPage("/User");
        }

        public IActionResult OnGetLogout()
        {
            _userApplication.Logout();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostRegister(RegisterUser command)
        {
            var result = _userApplication.Register(command);
            if (result.IsSuccedded)
                return RedirectToPage("/User");
            RegisterMessage = result.Message;
            return RedirectToPage("/User");
        }
    }
}
