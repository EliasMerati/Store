using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Common.Roles;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistance.Context
{
    public class StoreDBContext :DbContext , IStoreDBContext
    {
        public StoreDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1 , RoleName = nameof(userRoles.Admin)});
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, RoleName = nameof(userRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, RoleName = nameof(userRoles.Customer) });


            //یونیک کردن فیلد ایمیل و یوزر نیم برای ثبت نام فقط یک بار
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(x => x.FullName).IsUnique();

            //نمایش فقط حذف نشده ها
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
        }
    }
}
