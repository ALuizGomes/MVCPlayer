using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MVCPlayer.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name = "Andre", int numTimes = 4)
        {
            ViewData["Message"] = "Hello" + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}