using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System;

namespace Store.Application.Services.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IStoreDBContext _db;
        public RemoveUserService(IStoreDBContext db)
        {
            _db = db;
        }
        public ResultDto Execute(long UserId)
        {
            var User = _db.Users.Find(UserId);
            if (User == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                }; 
            }
            User.RemoveTime = DateTime.Now;
            User.IsRemoved = true;
            _db.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت حذف شد"
            };
        }
    }
}
