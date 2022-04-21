using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Commands.EditUser
{
    public interface IEditUserService
    {
        ResultDto Execute(RequestEditUserDto request);
    }

    public class EditUserService : IEditUserService
    {
        private readonly IStoreDBContext _db;
        public EditUserService(IStoreDBContext db)
        {
            _db = db;
        }
        public ResultDto Execute(RequestEditUserDto request)
        {
            var user = _db.Users.Find(request.Id);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربری با مشخصات فوق یافت نشد",
                };
            }
            user.Email = request.Email;
            user.FullName = request.FullName;
            _db.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت ویرایش شد",
            };
        }
    }

    public class RequestEditUserDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
