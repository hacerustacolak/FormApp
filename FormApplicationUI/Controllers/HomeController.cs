using FormApplication.Service.Abstract;
using FormApplicationUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FormApplicationUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFormService _formService;

        public HomeController(IFormService formService)
        {
            _formService = formService;
        }

        public IActionResult Index()
        {
            var response = _formService.GetAll();
            return View(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
