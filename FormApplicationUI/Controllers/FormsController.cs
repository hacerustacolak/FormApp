using FormApplication.Data.DomainClass;
using FormApplication.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FormApplicationUI.Controllers
{
    public class FormsController : Controller
    {
        private readonly IFormService _formService;

        public FormsController(IFormService formService)
        {
            _formService = formService;
        }

        public ActionResult List()
        {
            var session = HttpContext.Session.GetString("SessionVariable");
            if (session == "HacerUstaColak")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }

        }


        public ActionResult Detail(int id)
        {
            var currentHost = HttpContext.Request.Host;
            var currentURL = currentHost.ToString() + "/" + id.ToString();
            var url = new Uri(currentURL);

            var session = HttpContext.Session.GetString("SessionVariable");
            if (session == "HacerUstaColak")
            {
                ViewData["id"] = id;
                return View("Detail");
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }

        }

        [HttpPost]
        public JsonResult GetAll()
        {
            var response = _formService.GetAll();
            return Json(response);
        }

        [HttpPost]
        public JsonResult GetById(int Id)
        {
            var response = _formService.GetById(Id);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Add(Forms forms)
        {
            forms.CreatedAt = DateTime.Now;
            forms.CreatedBy = 1;
            var response = _formService.Add(forms);
            return Json(response);
        }

        [HttpPost]
        public JsonResult AddData(FormDetails formDetails)
        {
            var response = _formService.AddData(formDetails);
            return Json(response);
        }
    }
}
