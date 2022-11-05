using System;
using UserManagement.Application.Contracts.User;
using ShopManagement.Domain.Services;

namespace ShopManagement.Infrastructure.UserAcl
{
    public class ShopUserAcl : IShopUserAcl
    {
        private readonly IUserApplication _userApplication;

        public ShopUserAcl(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public (string name, string mobile) GetUserBy(long id)
        {
            var user = _userApplication.GetUserBy(id);
            return (user.Fullname, user.Mobile);
        }
    }
}