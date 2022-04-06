using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Users.Commands.RegisterUser;
using Store.Application.Services.Users.Queries.GetRoles;
using Store.Application.Services.Users.Queries.GetUsers;
using System.Collections.Generic;

namespace Store.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        public HomeController(IGetUsersService getUsersService,
            IGetRolesService getRolesService,
            IRegisterUserService registerUserService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
        }


        public IActionResult Index(string searchkey, int page = 1)
        {
            return View(_getUsersService.Execute(new RequestGetUsers
            {
                SearchKey = searchkey,
                Page = page,
            }));
        }

        public IActionResult Create()
        {
            ViewBag.roles = new SelectList(_getRolesService.Execute().Data, "Id", "RoleName");
            return View("RegisterUser");
        }

        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var Result = _registerUserService.Execute(new RequestUserRegisterDto()
            {
                Email = Email,
                FullName = FullName,
                Roles = new List<RolesInUserRegisterDto>()
                {
                    new RolesInUserRegisterDto
                    {
                        Id = RoleId
                    }
                },
               Password = Password,
               RePassword = RePassword
            });
            return Json(Result);
        }
    }
}
