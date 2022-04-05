using Store.Application.Interfaces.Context;
using Store.Common;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IStoreDBContext _context;
        public GetUsersService(IStoreDBContext context)
        {
            _context = context;
        }
        public ResultGetUsersDto Execute(RequestGetUsers request)
        {
            var users = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));
            }

            int rowscount = 0;
            var userlist =  users.ToPaged(request.Page , 20,out rowscount).Select(p => new GetUserDto
            {
                FullName = p.FullName,
                Email = p.Email,
                Id = p.Id,
            }).ToList();

            return new ResultGetUsersDto{
                Rows = rowscount,
                Users = userlist,

            };
        }
    }
}
