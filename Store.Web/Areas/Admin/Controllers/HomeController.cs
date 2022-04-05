using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Users.Queries.GetUsers;

namespace Store.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        public HomeController(IGetUsersService getUsersService)
        {
            _getUsersService = getUsersService;
        }

        [Area("Admin")]
        public IActionResult Index(string searchkey , int page = 1)
        {
            return View(_getUsersService.Execute( new RequestGetUsers
            {
                SearchKey = searchkey,
                Page = page,
            }));
        }
    }
}
