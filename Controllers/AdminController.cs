using Microsoft.AspNetCore.Mvc;

namespace DesafioMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Categories() {
            return View();
        }

        public IActionResult NewCategory() {
            return View();
        }

        public IActionResult Businesses() {
            return View();
        }

        public IActionResult NewBusiness() {
            return View();
        }
    }
}