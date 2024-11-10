using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using programowanieASP.NET.Models;

namespace programowanieASP.NET.Controllers
{
    public class TravelController : Controller
    {
        private readonly ITravelService _travelService;
        //static Dictionary<int, TravelModel> _travel = new Dictionary<int, TravelModel>();
        public TravelController(ITravelService travelService)
        {
            _travelService = travelService ?? throw new ArgumentNullException(nameof(travelService));
        }

        public IActionResult Index()
        {
            return View(_travelService.FindAll());
        }

        [HttpGet]
        public IActionResult TravelForm()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TravelModel travel)
        {

            if (travel.Uczestnicy == null)
            {
                travel.Uczestnicy = new List<string>();
            }
            if (ModelState.IsValid)
            {
                _travelService.Add(travel);
                //int id = _travel.Keys.Count != 0 ? _travel.Keys.Max() : 0;
                //travel.Id = id + 1;
                return RedirectToAction("Index");

            }
            else
            {
                return View(travel);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var travel = _travelService.FindById(id);
            if (travel != null)
                return View(travel);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(TravelModel travel)
        {
            if (ModelState.IsValid)
            {
                if (travel.Uczestnicy == null)
                {
                    travel.Uczestnicy = new List<string>();
                }
                _travelService.Update(travel);
                return RedirectToAction("Index");
            }
            return View(travel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var travel = _travelService.FindById(id);
            if (travel != null)
                return View(travel);
            return NotFound();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var travel = _travelService.FindById(id);
            if (travel != null)
                return View(travel);
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var travel = _travelService.FindById(id);
            if (travel != null)
                _travelService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
