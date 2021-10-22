using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TutorWebApp.Models;

namespace TutorWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
         
            return View();
        }
        public IActionResult Requests(int page, Filter filter)
        {
            if (page == 0) page = 1;
            ViewBag.filter = filter;
            ViewBag.page = page;
            return View();
        }

        [Authorize]
      
        public IActionResult PostRequest(Request request)
        {
                if (string.IsNullOrEmpty(request.Title)) { ModelState.AddModelError("Titlu", "Te rugam sa introduci un titlu!"); }
                if (string.IsNullOrEmpty(request.Details)) { ModelState.AddModelError("Descriere", "Te rugam sa introduci o descriere!"); }
                if (string.IsNullOrEmpty(request.CategoryId.ToString())) { ModelState.AddModelError("Categorie", "Te rugam sa alegi o categorie!"); }


                if (ModelState.IsValid)
                {
                    Operations.DatabaseOperations.InsertRequest(request);
                    return RedirectToAction("Index");
                }
                else return View();
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
