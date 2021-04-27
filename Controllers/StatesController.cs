using DesafioMVC.Data;
using DesafioMVC.DTO;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMVC.Controllers
{
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
    }
}