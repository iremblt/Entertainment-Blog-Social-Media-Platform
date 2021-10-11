using Entertainment_Blog.DataAccess.Concrete.EntityFramework.Repositories;
using Entertainment_Blog__Social_Media_Platform.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Entertainment_Blog__Social_Media_Platform.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EfPostRepository ef;

        public HomeController(ILogger<HomeController> logger,EfPostRepository _ef)
        {
            _logger = logger;
            ef = _ef;
        }

        public IActionResult Index()
        {
            return View();
        }           
        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult DemoList()
        {
            return View(DemoRepository.Demos.ToList());
        }
        [HttpGet]
        public IActionResult DemoAdd()
        {
            return View();
        }        
        [HttpPost]
        public IActionResult DemoAdd(Demo demo)
        {
            if (ModelState.IsValid)
            {
                DemoRepository.AddDemo(demo);
                return RedirectToAction("Index");
            }
            return View(demo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
