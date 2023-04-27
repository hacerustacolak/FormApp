using FormApplication.Core;
using FormApplication.Service.Abstract;
using FormApplication.Service.Concrete;
using Microsoft.AspNetCore.Http;
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

        public ActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        public JsonResult Login(UserDto request)
        {

            var isUser = _userService.Login(request);
            if (isUser)
            {
                // Set a value in the session
                HttpContext.Session.SetString("SessionVariable", "HacerUstaColak");


            }
            return Json(isUser);

        }

        [HttpPost]
        public JsonResult Logout()
        {
            HttpContext.Session.Clear(); 
            return Json(true);

        }


    }
}
