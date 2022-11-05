using _0_Framework.Application;
using _0_Framework.Infrastructure;
using UserManagement.Application.Contracts.User;
using UserManagement.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UserManagement.Infrastructure.EFCore.Repository
{
    public class UserRepository : RepositoryBase<long, User>, IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context) : base(context)
        {
            _context = context;
        }

        public User GetBy(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

        public EditUser GetDetails(long id)
        {
            return _context.Users.Select(x => new EditUser
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                Username = x.Username
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<UserViewModel> GetUsers()
        {
            return _context.Users.Select(x => new UserViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname
            }).ToList();
        }

        public List<UserViewModel> Search(UserSearchModel searchModel)
        {
            var query = _context.Users.Include(x => x.Role).Select(x => new UserViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                Role = x.Role.Name,
                RoleId = x.RoleId,
                Username = x.Username,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Fullname))
                query = query.Where(x => x.Fullname.Contains(searchModel.Fullname));

            if (!string.IsNullOrWhiteSpace(searchModel.Username))
                query = query.Where(x => x.Username.Contains(searchModel.Username));

            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query = query.Where(x => x.Mobile.Contains(searchModel.Mobile));

            if (searchModel.RoleId > 0)
                query = query.Where(x => x.RoleId == searchModel.RoleId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}