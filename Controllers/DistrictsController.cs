using System;
using System.Linq;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioMVC.Controllers
{
    [Authorize(Policy = "ADM")]
    public class DistrictsController : Controller
    {
        private readonly ApplicationDbContext _database;

        public DistrictsController(ApplicationDbContext database) {
            _database = database;
        }

        public IActionResult DistrictsByState(int id) {
            var districts = _database.Districts
                .Include(district => district.City)
                .Where(district => district.City.Id == id)
                .ToList();
            return Ok(districts);
        }

        [HttpPost]
        public IActionResult Save(DistrictDTO tempDistrict) {
            if (ModelState.IsValid) {
                District district = new District();
                district.Name = tempDistrict.Name;
                district.City = _database.Cities.First(city => city.Id == tempDistrict.CityId);
                _database.Districts.Add(district);
                _database.SaveChanges();
                return RedirectToAction("Districts", "Admin");
            } else {
                ViewBag.States = _database.States.ToList();
                return View("../Admin/NewDistrict");
            }
        }

        [HttpPost]
        public IActionResult Edit(DistrictDTO tempDistrict) {
            if (ModelState.IsValid) {
                var district = _database.Districts.First(dist => dist.Id == tempDistrict.Id);
                district.Name = tempDistrict.Name;
                district.City = _database.Cities.First(city => city.Id == tempDistrict.CityId);
                _database.SaveChanges();
                return RedirectToAction("Districts", "Admin");
            } else {
                ViewBag.States = _database.States.ToList();
                ViewBag.CitiesByState = _database.Cities.Where(city => city.State.Id == tempDistrict.StateId).ToList();
                return View("../Admin/EditDistrict");
            }
        }

        [HttpPost]
        public IActionResult Delete(int id) {
            if (id > 0) {
                try {
                    var district = _database.Districts.First(dist => dist.Id == id);
                    _database.Remove(district);
                    _database.SaveChanges();
                } catch (Exception) {
                    TempData["Error"] = true;
                }
            }
            return RedirectToAction("Districts", "Admin");
        }
    }
}