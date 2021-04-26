using DesafioMVC.Data;
using DesafioMVC.DTO;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _database;

        public CategoriesController(ApplicationDbContext database) {
            _database = database;
        }

        [HttpPost]
        public IActionResult Save(CategoryDTO tempCategory) {
            if (ModelState.IsValid) {
                Category category = new Category();
                category.Name = tempCategory.Name;
                _database.Categories.Add(category);
                _database.SaveChanges();
                return RedirectToAction("Categories", "Admin");
            } else {
                return View("../Admin/NewCategory");
            }
        }
    }
}