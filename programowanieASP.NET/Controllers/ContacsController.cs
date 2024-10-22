using Microsoft.AspNetCore.Mvc;

namespace programowanieASP.NET.Controllers;

public class ContacsController : Controller
{
    // lista kontaktow
    public IActionResult Index()
    {
        return View();
    }
    
    //Formularz dodania kontaktow
    public IActionResult Add()
    {
        return View();
    }
}