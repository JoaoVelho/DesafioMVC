using System.Linq;
using DesafioMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _database;

        public AdminController(ApplicationDbContext database) {
            _database = database;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Categories() {
            var categories = _database.Categories.ToList();
            return View(categories);
        }

        public IActionResult NewCategory() {
            return View();
        }

        public IActionResult Businesses() {
            var businesses = _database.Businesses.ToList();
            return View(businesses);
        }

        public IActionResult NewBusiness() {
            return View();
        }

        public IActionResult States() {
            var states = _database.States.ToList();
            return View(states);
        }
    }
}