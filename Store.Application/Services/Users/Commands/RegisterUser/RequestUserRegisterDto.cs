using Store.Application.Services.Users.Commands.RegisterUser;
using System.Collections.Generic;

namespace Store.Application.Services.Users.Commands.RegisterUser
{
    public class RequestUserRegisterDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public List<RolesInUserRegisterDto> Roles { get; set; }
    }
}
