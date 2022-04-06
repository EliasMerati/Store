using Store.Application.Interfaces.Context;
using Store.Application.Services.Users.Commands.RegisterUser;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System.Collections.Generic;

namespace Store.Application.Services.Users.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IStoreDBContext _db;
        public RegisterUserService(IStoreDBContext db)
        {
            _db = db;
        }
        public ResultDto<ResultRegisterUserDto> Execute(RequestUserRegisterDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام کاربری را وارد کنید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "ایمیل را وارد کنید"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور را وارد کنید"
                    };
                }

                if (request.Password != request.RePassword)
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور و تکرار رمز عبور برابر نیست"
                    };
                }

                User user = new User()
                {
                    Email = request.Email,
                    FullName = request.FullName,
                };

                List<UserRoles> userRoles = new List<UserRoles>();
                foreach (var item in request.Roles)
                {
                    var roles = _db.Roles.Find(item.Id);
                    userRoles.Add(new UserRoles()
                    {
                        RoleId = roles.Id,
                        Role = roles,
                        User = user,
                        UserId = user.Id
                    });

                }
                user.UserRoles = userRoles;

                _db.Users.Add(user);
                _db.SaveChanges();

                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto
                    {
                        UserId = user.Id,

                    },
                    IsSuccess = true,
                    Message = "ثبت نام کاربر با موفقیت انجام شد"
                };
            }
            catch (System.Exception)
            {
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto
                    {
                        UserId = 0,
                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد"
                };
            }

        }
    }
}
