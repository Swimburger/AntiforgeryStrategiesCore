using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AntiForgeryStrategiesCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(IFormCollection form)
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
