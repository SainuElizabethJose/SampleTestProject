using Microsoft.AspNetCore.Mvc;
using MVCWebApplication_SampleTest.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MVCWebApplication_SampleTest.Controllers
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
        public IActionResult FormSubmit(PersonName personname)
        {
            string json = JsonConvert.SerializeObject(personname);
            System.IO.File.WriteAllText("personName.json", json);
            TempData["AlertMessage"] = "Person Name in JSON format has been saved in personName.json file!";
            return RedirectToAction("Index");
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
