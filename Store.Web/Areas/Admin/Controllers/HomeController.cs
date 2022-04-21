using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Users.Commands.EditUser;
using Store.Application.Services.Users.Commands.RegisterUser;
using Store.Application.Services.Users.Commands.RemoveUser;
using Store.Application.Services.Users.Queries.GetRoles;
using Store.Application.Services.Users.Queries.GetUserById;
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
        private readonly IRemoveUserService _removeUserService;
        private readonly IEditUserService _editUserService;
        private readonly IGetUserByIdService _getUserByIdService;
        public HomeController(IGetUsersService getUsersService,
            IGetRolesService getRolesService,
            IRegisterUserService registerUserService,
            IRemoveUserService removeUserService,
            IEditUserService editUserService,
            IGetUserByIdService getUserByIdService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _editUserService = editUserService;
            _getUserByIdService = getUserByIdService;
        }


        public IActionResult Index(string searchkey, int page = 1)
        {
            return View(_getUsersService.Execute(new RequestGetUsers
            {
                SearchKey = searchkey,
                Page = page,
            }));
        }


        [HttpGet]
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
            return RedirectToAction(nameof(Index),Result);
        }


        [HttpPost]
        public IActionResult Delete(long id)
        {
            _removeUserService.Execute(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var user = _getUserByIdService.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(long id , string FullName,string Email)
        {
            return View(_editUserService.Execute( new RequestEditUserDto
            {
                Email = Email,
                FullName= FullName,
                Id = id,
            }));
        }
    }
}
