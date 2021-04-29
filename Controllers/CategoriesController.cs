using System;
using System.Linq;
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

        [HttpPost]
        public IActionResult Edit(CategoryDTO tempCategory) {
            if (ModelState.IsValid) {
                var category = _database.Categories.First(cat => cat.Id == tempCategory.Id);
                category.Name = tempCategory.Name;
                _database.SaveChanges();
                return RedirectToAction("Categories", "Admin");
            } else {
                return View("../Admin/EditCategory");
            }
        }

        [HttpPost]
        public IActionResult Delete(int id) {
            if (id > 0) {
                try {
                    var category = _database.Categories.First(cat => cat.Id == id);
                    _database.Remove(category);
                    _database.SaveChanges();
                } catch (Exception) {
                    TempData["Error"] = true;
                }
            }
            return RedirectToAction("Categories", "Admin");
        }
    }
}