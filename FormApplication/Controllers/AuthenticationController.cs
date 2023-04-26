using FormApplication.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FormApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        } 

        public ActionResult Login()
        { 
            return View();
        }
    }
}
