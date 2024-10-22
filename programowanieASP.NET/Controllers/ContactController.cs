using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;

namespace programowanieASP.NET.Controllers;

public class ContactController : Controller
{
    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1, new ContactModel()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Abecki",
                Email = "adam@becki.com",
                BirthDate = new DateOnly(year: 1999, month: 10, day: 10),
                PhoneNumber = "222-999-666"
            }
        }
    };

    // lista kontaktow
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    //Formularz dodania kontaktow
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.Id = ++currenId;
        _contacts.Add(model.Id, model);
        return View("Index", _contacts);

        return View("Index");
    }

    public IActionResult Add(ContactModel model)
    {
        if(!ModelState.)
    }
}