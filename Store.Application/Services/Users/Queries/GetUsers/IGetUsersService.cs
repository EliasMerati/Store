using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUsersService
    {
        ResultGetUsersDto Execute(RequestGetUsers request);
    }
}
