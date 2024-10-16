using Microsoft.AspNetCore.Mvc;
using programowanieASP.NET.Models;

namespace programowanieASP.NET.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Result(Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            return View(model);
        }
        public IActionResult Form()
        {
            return View();
        }
    }
}
