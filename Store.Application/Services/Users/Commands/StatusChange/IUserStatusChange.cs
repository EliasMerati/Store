using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Commands.StatusChange
{
    public interface IUserStatusChange
    {
        ResultDto Execute(long id);
    }
    public class UserStatusChange : IUserStatusChange
    {
        private readonly IStoreDBContext _db;
        public UserStatusChange(IStoreDBContext db)
        {
            _db = db;
        }
        public ResultDto Execute(long id)
        {
            var user = _db.Users.Find(id);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد",
                };

            }
            user.IsActive = !user.IsActive;
            _db.SaveChanges();
            string userstate = user.IsActive == true ? "فعال" : "غیر فعال";
            return new ResultDto
            {
                IsSuccess = true,
                Message = $"کاربر  با موفقیت {userstate} شد"
            };
        }

    }
}

