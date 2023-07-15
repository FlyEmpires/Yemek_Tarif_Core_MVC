using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.ViewModel;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Yemek_Tarif_Core_MVC.Models;

namespace Yemek_Tarif_Core_MVC.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		WriterManager wm = new(new EFWriterRepository());
		public IActionResult Index()
		{
			Context db = new();
			var values = (from city in db.Cities.ToList() join district in db.Districts on city.Id equals district.Id select city).Distinct().ToList();
            WriterCityViewModel cd = new()
            {
                City = values,
                SelectedCityID = values.FirstOrDefault().Id,
                District = values.FirstOrDefault().Districts,
                DistrictID = values.FirstOrDefault().Districts.FirstOrDefault().DistrictID
            };
            return View(cd);
        }
		[HttpPost]
		public IActionResult Index(WriterCityViewModel p,string geciciSifre ,int SelectedDistrictID)
		{
			Context db = new();
			var cityList = (from i in db.Cities.ToList() select i).ToList();
			p.City = cityList;
			WriterValidator wv = new(geciciSifre);
			ValidationResult results = wv.Validate(p);
			if (results.IsValid)
			{
			p.Writers.WriterStatus = true;
			p.Writers.WriterAbout = "Deneme";
			p.Writers.DistrictID = SelectedDistrictID;
			p.Writers.CityID= p.SelectedCityID;
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
        [HttpPost]
        public IActionResult City(int selectedCity)
        {
			Context db = new();
            var districts = db.Districts.Where(d => d.Id == selectedCity).ToList();
            return Json(districts);
        }
    }
}