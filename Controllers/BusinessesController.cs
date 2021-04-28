using System.Linq;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMVC.Controllers
{
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
    }
}