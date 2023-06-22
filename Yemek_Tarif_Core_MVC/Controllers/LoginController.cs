using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class LoginController : Controller
    {
        WriterManager wm = new(new EFWriterRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Index(Writer p)
		{
            var value=wm.WriterLogin(p);
			return View(value);
		}
	}
}
