using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.ViewModel;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Yemek_Tarif_Core_MVC.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager wm = new(new EFWriterRepository());
		public IActionResult Index()
		{
			Context db = new();
			var cityList=(from i in db.Cities.ToList() select i).ToList();
			WriterCityViewModel viewModel = new()
			{
				Cities=cityList,
				SelectedCityId=cityList.FirstOrDefault().Id
			};
			
			return View(viewModel);
		}
		[HttpPost]
		public IActionResult Index(WriterCityViewModel p,string geciciSifre)
		{
			Context db = new();
			var cityList = (from i in db.Cities.ToList() select i).ToList();
			p.Cities = cityList;
			WriterValidator wv = new(geciciSifre);
			ValidationResult results = wv.Validate(p);
			if (results.IsValid)
			{

			p.Writers.WriterStatus = true;
			p.Writers.WriterAbout = "Deneme";
			if (geciciSifre != p.Writers.WriterPassword) //Bunun yerine fluentvalidation ile kontrolünü sağladım
			{
				ViewBag.hata = "Girdiğiniz Şifreler Birbiriyle Uyuşmuyor. Lütfen Tekrar Kontrol Ediniz...";
			}
			else
			{
				wm.WriterAdd(p.Writers);
			}
			return RedirectToAction("Index","Recipe");
            }
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View(p);
        }
    }
}