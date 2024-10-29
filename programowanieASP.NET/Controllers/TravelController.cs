using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using programowanieASP.NET.Models;
using AspNetCore;

namespace programowanieASP.NET.Controllers
{
    public class TravelController : Controller
    {
        static Dictionary<int, TravelModel> _travel = new Dictionary<int, TravelModel>();

        public IActionResult Index() { 
            return View(_travel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
      
        [HttpPost]
        public IActionResult Create(TravelModel travel)
        {
            if (ModelState.IsValid)
            {
                int id = _travel.Keys.Count != 0 ? _travel.Keys.Max() : 0;
                travel.Id = id + 1;
                _travel.Add(travel.Id, travel);

                return RedirectToAction("Index");

            } else
            {
                return View(travel);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (_travel.ContainsKey(id))
                return View(_travel[id]);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(TravelModel travel)
        {
            if (ModelState.IsValid)
            {
                _travel[travel.Id] = travel;
                return RedirectToAction("Index");
            }
            return View(travel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (_travel.ContainsKey(id))
                return View(_travel[id]);
            return NotFound();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (_travel.ContainsKey(id))
                return View(_travel[id]);
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_travel.ContainsKey(id))
                _travel.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
