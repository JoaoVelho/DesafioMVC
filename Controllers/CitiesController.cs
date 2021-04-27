using System.Linq;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioMVC.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ApplicationDbContext _database;

        public CitiesController(ApplicationDbContext database) {
            _database = database;
        }

        public IActionResult CitiesByState(int id) {
            var cities = _database.Cities
                .Include(city => city.State)
                .Where(city => city.State.Id == id)
                .ToList();
            return Ok(cities);
        }

        [HttpPost]
        public IActionResult Save(CityDTO tempCity) {
            if (ModelState.IsValid) {
                City city = new City();
                city.Name = tempCity.Name;
                city.State = _database.States.First(state => state.Uf == tempCity.StateUf);
                _database.Cities.Add(city);
                _database.SaveChanges();
                return RedirectToAction("Cities", "Admin");
            } else {
                ViewBag.States = _database.States.ToList();
                return View("../Admin/NewCity");
            }
        }
    }
}