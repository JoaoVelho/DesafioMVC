using Microsoft.AspNetCore.Mvc;

namespace DesafioMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index() {
            return View();
        }
    }
}