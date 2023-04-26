using FormApplication.Core;
using FormApplication.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace FormApplicationUI.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(UserDto request)
        {

            var isUser = _userService.Login(request);
            if (isUser)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginError = "Böyle bir kullanıcı yoktur.";
                return View();
            }

        }


    }
}
