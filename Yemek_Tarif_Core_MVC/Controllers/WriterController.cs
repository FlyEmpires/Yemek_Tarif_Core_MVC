using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        public IActionResult Writer()
        {
            return View();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
    }
}
