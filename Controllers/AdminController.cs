using System.Linq;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioMVC.Controllers
{
    [Authorize(Policy = "ADM")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _database;

        public AdminController(ApplicationDbContext database) {
            _database = database;
        }

        public IActionResult Index() {
            var properties = _database.Properties
                .Include(prop => prop.Category)
                .Include(prop => prop.Business)
                .Include(prop => prop.District.City.State)
                .ToList();
            return View(properties);
        }

        public IActionResult Categories() {
            var categories = _database.Categories.ToList();
            return View(categories);
        }

        public IActionResult NewCategory() {
            return View();
        }

        public IActionResult EditCategory(int id) {
            var category = _database.Categories.First(cat => cat.Id == id);
            CategoryDTO categoryView = new CategoryDTO();
            categoryView.Id = category.Id;
            categoryView.Name = category.Name;
            return View(categoryView);
        }

        public IActionResult Businesses() {
            var businesses = _database.Businesses.ToList();
            return View(businesses);
        }

        public IActionResult NewBusiness() {
            return View();
        }

        public IActionResult EditBusiness(int id) {
            var business = _database.Businesses.First(bus => bus.Id == id);
            BusinessDTO businessView = new BusinessDTO();
            businessView.Id = business.Id;
            businessView.Name = business.Name;
            return View(businessView);
        }

        public IActionResult States() {
            var states = _database.States.ToList();
            return View(states);
        }

        public IActionResult NewState() {
            return View();
        }

        public IActionResult Cities() {
            var cities = _database.Cities.Include(city => city.State).ToList();
            return View(cities);
        }

        public IActionResult NewCity() {
            var states = _database.States.ToList();
            ViewBag.States = states;

            if (states.Count() == 0) {
                TempData["NoState"] = true;
                return RedirectToAction("Cities", "Admin");
            }

            return View();
        }

        public IActionResult Districts() {
            var districts = _database.Districts
                .Include(district => district.City.State)
                .ToList();
            return View(districts);
        }

        public IActionResult NewDistrict() {
            if (_database.Cities.ToList().Count() == 0) {
                TempData["NoCity"] = true;
                return RedirectToAction("Districts", "Admin");
            }

            ViewBag.States = _database.States.ToList();
            return View();
        }

        public IActionResult EditDistrict(int id) {
            var district = _database.Districts.Include(dist => dist.City.State).First(dist => dist.Id == id);
            DistrictDTO districtView = new DistrictDTO();
            districtView.Id = district.Id;
            districtView.Name = district.Name;
            districtView.CityId = district.City.Id;
            districtView.StateId = district.City.State.Id;

            ViewBag.States = _database.States.ToList();
            ViewBag.CitiesByState = _database.Cities.Where(city => city.State.Id == districtView.StateId).ToList();
            return View(districtView);
        }

        public IActionResult Properties() {
            var properties = _database.Properties
                .Include(prop => prop.Category)
                .Include(prop => prop.Business)
                .Include(prop => prop.District.City.State)
                .ToList();
            return View(properties);
        }

        public IActionResult NewProperty() {
            ViewBag.Categories = _database.Categories.ToList();
            ViewBag.Businesses = _database.Businesses.ToList();
            ViewBag.States = _database.States.ToList();
            return View();
        }

        public IActionResult EditProperty(int id) {
            var property = _database.Properties
                .Include(prop => prop.Category)
                .Include(prop => prop.Business)
                .Include(prop => prop.District.City.State)
                .First(prop => prop.Id == id);
            PropertyEditDTO propertyView = new PropertyEditDTO();
            propertyView.Id = property.Id;
            propertyView.CategoryId = property.Category.Id;
            propertyView.BusinessId = property.Business.Id;
            propertyView.StateId = property.District.City.State.Id;
            propertyView.CityId = property.District.City.Id;
            propertyView.DistrictId = property.District.Id;
            propertyView.Address = property.Address;
            propertyView.Rooms = property.Rooms;

            ViewBag.Categories = _database.Categories.ToList();
            ViewBag.Businesses = _database.Businesses.ToList();
            ViewBag.States = _database.States.ToList();
            ViewBag.CitiesByState = _database.Cities.Where(city => city.State.Id == propertyView.StateId).ToList();
            ViewBag.DistrictsByCity = _database.Districts.Where(dist => dist.City.Id == propertyView.CityId).ToList();
            return View(propertyView);
        }
    }
}