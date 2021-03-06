using System;
using System.Linq;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMVC.Controllers
{
    [Authorize(Policy = "ADM")]
    public class BusinessesController : Controller
    {
        private readonly ApplicationDbContext _database;

        public BusinessesController(ApplicationDbContext database) {
            _database = database;
        }

        [HttpPost]
        public IActionResult Save(BusinessDTO tempBusiness) {
            if (ModelState.IsValid) {
                Business business = new Business();
                business.Name = tempBusiness.Name;
                _database.Businesses.Add(business);
                _database.SaveChanges();
                return RedirectToAction("Businesses", "Admin");
            } else {
                return View("../Admin/NewBusiness");
            }
        }

        [HttpPost]
        public IActionResult Edit(BusinessDTO tempBusiness) {
            if (ModelState.IsValid) {
                var business = _database.Businesses.First(bus => bus.Id == tempBusiness.Id);
                business.Name = tempBusiness.Name;
                _database.SaveChanges();
                return RedirectToAction("Businesses", "Admin");
            } else {
                return View("../Admin/EditBusiness");
            }
        }

        [HttpPost]
        public IActionResult Delete(int id) {
            if (id > 0) {
                try {
                    var business = _database.Businesses.First(bus => bus.Id == id);
                    _database.Remove(business);
                    _database.SaveChanges();
                } catch (Exception) {
                    TempData["Error"] = true;
                }
            }
            return RedirectToAction("Businesses", "Admin");
        }
    }
}