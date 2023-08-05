using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminNavbarPartial()
        {
            return View();
        }
    }
}
