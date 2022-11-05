using UserManagement.Domain.UserAgg;
using UserManagement.Domain.RoleAgg;
using UserManagement.Infrastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;
using System;

namespace UserManagement.Infrastructure.EFCore
{
    public class UserContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
