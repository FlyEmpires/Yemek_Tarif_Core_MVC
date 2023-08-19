using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.Areas.Admin.Controllers
{
    public class WidgetsController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
