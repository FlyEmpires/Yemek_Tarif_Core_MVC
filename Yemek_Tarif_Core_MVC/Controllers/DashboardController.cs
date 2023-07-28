using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
