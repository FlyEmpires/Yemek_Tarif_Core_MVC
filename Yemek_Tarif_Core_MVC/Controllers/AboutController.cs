using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.Controllers
{
	public class AboutController : Controller
	{
		AboutManager abm=new(new EFAboutRepository());
		public IActionResult Index()
		{
            var values = abm.GetList();

            return View(values);
		}
		public PartialViewResult SocialMediaAbout()
		{
			var values=abm.GetList();
			return PartialView(values);
		}
	}
}
