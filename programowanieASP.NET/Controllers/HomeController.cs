using Microsoft.AspNetCore.Mvc;
using programowanieASP.NET.Models;
using System.Diagnostics;

namespace programowanieASP.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Calculator(Operator? op, double? a, double? b)
        {
            //Example of query: /Home/Calculator?op=Add&a=5&b=3
            // var op = Request.Query["op"];
            // var a = double.Parse( Request.Query["a"]);
            // var b = double.Parse(Request.Query["b"]);
            if (a is null || b is null)
            {
                ViewBag.ErrorMessage = "Invalid number format in parameter a or b!!!";
                return View("CustomError");
            }

            if (op is null)
            {
                ViewBag.ErrorMessage = "Unknown operator!!!";
                return View("CustomError");
            }
            ViewBag.A = a;
            ViewBag.B = b;
            switch (op)
            {
                case Operator.Add:
                    ViewBag.Result = a + b;
                    ViewBag.Operator = "+";
                    break;
                case Operator.Sub:
                    ViewBag.Result = a - b;
                    ViewBag.Operator = "-";
                    break;
                case Operator.Div:
                    ViewBag.Result = a / b;
                    ViewBag.Operator = "/";
                    break;
                case Operator.Mul:
                    ViewBag.Result = a * b;
                    ViewBag.Operator = "*";
                    break;
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
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
    public enum Operator
    {
        Add, Sub, Div, Mul,
    }
}
