using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Users.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IStoreDBContext _db;
        public GetRolesService(IStoreDBContext db)
        {
            _db = db;
        }
        public ResultDto<List<RolesDto>> Execute()
        {
            var roles = _db.Roles.Select(p => new RolesDto()
            {
                Id = p.Id,
                RoleName = p.RoleName,
            }).ToList();

            return new ResultDto<List<RolesDto>>()
            {
                Data = roles,
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
