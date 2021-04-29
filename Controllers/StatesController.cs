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
    public class StatesController : Controller
    {
        private readonly ApplicationDbContext _database;

        public StatesController(ApplicationDbContext database) {
            _database = database;
        }

        [HttpPost]
        public IActionResult Save(StateDTO tempState) {
            if (ModelState.IsValid) {
                State state = new State();
                state.Uf = tempState.Uf;
                state.Name = tempState.Name;
                _database.States.Add(state);
                _database.SaveChanges();
                return RedirectToAction("States", "Admin");
            } else {
                return View("../Admin/NewState");
            }
        }

        [HttpPost]
        public IActionResult Delete(int id) {
            if (id > 0) {
                try {
                    var state = _database.States.First(state => state.Id == id);
                    _database.Remove(state);
                    _database.SaveChanges();
                } catch (Exception) {
                    TempData["Error"] = true;
                }
            }
            return RedirectToAction("States", "Admin");
        }
    }
}