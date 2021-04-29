using System;
using System.Linq;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMVC.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly ApplicationDbContext _database;

        public PropertiesController(ApplicationDbContext database) {
            _database = database;
        }

        [HttpPost]
        public IActionResult Save(PropertyDTO tempProperty) {
            if (ModelState.IsValid) {
                Property property = new Property();
                property.Category = _database.Categories.First(cat => cat.Id == tempProperty.CategoryId);
                property.Business = _database.Businesses.First(bus => bus.Id == tempProperty.BusinessId);
                property.District = _database.Districts.First(dist => dist.Id == tempProperty.DistrictId);
                property.Address = tempProperty.Address;
                property.Rooms = (int) tempProperty.Rooms;
                _database.Properties.Add(property);
                _database.SaveChanges();
                return RedirectToAction("Properties", "Admin");
            } else {
                ViewBag.Categories = _database.Categories.ToList();
                ViewBag.Businesses = _database.Businesses.ToList();
                ViewBag.States = _database.States.ToList();
                return View("../Admin/NewProperty");
            }
        }

        [HttpPost]
        public IActionResult Edit(PropertyDTO tempProperty) {
            if (ModelState.IsValid) {
                var property = _database.Properties.First(prop => prop.Id == tempProperty.Id);
                property.Category = _database.Categories.First(cat => cat.Id == tempProperty.CategoryId);
                property.Business = _database.Businesses.First(bus => bus.Id == tempProperty.BusinessId);
                property.District = _database.Districts.First(dist => dist.Id == tempProperty.DistrictId);
                property.Address = tempProperty.Address;
                property.Rooms = (int) tempProperty.Rooms;
                _database.SaveChanges();
                return RedirectToAction("Properties", "Admin");
            } else {
                ViewBag.Categories = _database.Categories.ToList();
                ViewBag.Businesses = _database.Businesses.ToList();
                ViewBag.States = _database.States.ToList();
                ViewBag.CitiesByState = _database.Cities.Where(city => city.State.Id == tempProperty.StateId).ToList();
                ViewBag.DistrictsByCity = _database.Districts.Where(dist => dist.City.Id == tempProperty.CityId).ToList();
                return View("../Admin/EditProperty");
            }
        }

        [HttpPost]
        public IActionResult Delete(int id) {
            if (id > 0) {
                try {
                    var property = _database.Properties.First(prop => prop.Id == id);
                    _database.Remove(property);
                    _database.SaveChanges();
                } catch (Exception) {
                    TempData["Error"] = true;
                }
            }
            return RedirectToAction("Properties", "Admin");
        }
    }
}