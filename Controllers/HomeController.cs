using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DesafioMVC.Models;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DesafioMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _database;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext database)
        {
            _logger = logger;
            _database = database;
        }

        public IActionResult Index() {
            ViewBag.Categories = _database.Categories.ToList();
            ViewBag.Businesses = _database.Businesses.ToList();
            ViewBag.States = _database.States.ToList();
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Search(SearchDataDTO tempSearch) {
            var propertiesFiltered = _database.Properties
                .Include(prop => prop.Category)
                .Include(prop => prop.Business)
                .Include(prop => prop.District.City.State)
                .Where(prop => tempSearch.CategoryId ==  0 ? true : prop.Category.Id == tempSearch.CategoryId)
                .Where(prop => tempSearch.BusinessId == 0 ? true : prop.Business.Id == tempSearch.BusinessId)
                .Where(prop => tempSearch.StateId == 0 ? true : prop.District.City.State.Id == tempSearch.StateId)
                .Where(prop => tempSearch.CityId == 0 ? true : prop.District.City.Id == tempSearch.CityId)
                .Where(prop => tempSearch.DistrictId == 0 ? true : prop.District.Id == tempSearch.DistrictId)
                .Where(prop => tempSearch.Rooms == null ? true : prop.Rooms == tempSearch.Rooms)
                .ToList();
            ViewBag.Properties = propertiesFiltered;

            ViewBag.Categories = _database.Categories.ToList();
            ViewBag.Businesses = _database.Businesses.ToList();
            ViewBag.States = _database.States.ToList();
            ViewBag.CitiesByState = _database.Cities.Where(city => city.State.Id == tempSearch.StateId).ToList();
            ViewBag.DistrictsByCity = _database.Districts.Where(dist => dist.City.Id == tempSearch.CityId).ToList();
            return View(tempSearch);
        }

        [Authorize]
        public IActionResult Property(int id) {
            var property = _database.Properties
                .Include(prop => prop.Category)
                .Include(prop => prop.Business)
                .Include(prop => prop.District.City.State)
                .First(prop => prop.Id == id);
            return View(property);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
