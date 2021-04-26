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
    }
}