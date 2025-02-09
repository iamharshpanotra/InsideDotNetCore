using Microsoft.AspNetCore.Mvc;

namespace TestApp1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            ViewData["data1"] = "NewGen";
            ViewData["data2"] = 25;
            ViewData["data3"] = DateTime.Now.ToLongDateString;

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
