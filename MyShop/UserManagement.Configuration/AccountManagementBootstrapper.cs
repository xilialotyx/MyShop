using UserManagement.Application;
using UserManagement.Application.Contracts.User;
using UserManagement.Application.Contracts.Role;
using UserManagement.Domain.UserAgg;
using UserManagement.Domain.RoleAgg;
using UserManagement.Infrastructure.EFCore;
using UserManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace UserManagement.Configuration
{
    public class UserManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUserApplication, UserApplication>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IRoleApplication, RoleApplication>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            services.AddDbContext<UserContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
