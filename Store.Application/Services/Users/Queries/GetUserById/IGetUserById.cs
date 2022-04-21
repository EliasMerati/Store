using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Queries.GetUserById
{
    public interface IGetUserByIdService
    {
        User GetUserById(long id);
    }
}
