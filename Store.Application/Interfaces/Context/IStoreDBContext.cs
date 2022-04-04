using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Interfaces.Context
{
    public interface IStoreDBContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserRoles> UserRoles { get; set; }


        int SaveChanges(bool AcceptAllChangeSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool AcceptAllChangeSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
