using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
