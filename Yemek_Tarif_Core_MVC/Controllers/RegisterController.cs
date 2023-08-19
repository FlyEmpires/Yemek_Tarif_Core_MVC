using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.ViewModel;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            var value = db.Cities.Include(d => d.District).ToList();
            //var values = (from district in db.Districts
            //              join city in db.Cities on district.CityID equals city.CityID
            //              select new District
            //              {
            //                  DistrictID = district.DistrictID,
            //                  DistrictName = district.DistrictName,
            //                  CityID = city.CityID,
            //                  City = city
            //              }).ToList();
            WriterCityViewModel cd = new()
            {
                City = value,
                SelectedCityID = value.FirstOrDefault().CityID,
                District = value.FirstOrDefault().District,
                DistrictID = value.FirstOrDefault().District.FirstOrDefault().DistrictID
            };
            return View(cd);
        }
        [HttpPost]
        public IActionResult Index(WriterCityViewModel p, string geciciSifre, int SelectedDistrictID)
        {
            Context db = new();
            var cityList = (from i in db.Cities.ToList() select i).ToList();
            var districtList = (from d in db.Districts where SelectedDistrictID == d.DistrictID select d).ToList();
            p.City = cityList;
            p.District = districtList;
            WriterValidator wv = new(geciciSifre);
            ValidationResult results = wv.Validate(p);
            if (results.IsValid)
            {
                p.Writers.WriterStatus = true;
                p.Writers.WriterAbout = "Deneme";
                p.Writers.DistrictID = SelectedDistrictID;
                p.Writers.CityID = p.SelectedCityID;
                if (geciciSifre != p.Writers.WriterPassword) //Bunun yerine fluentvalidation ile kontrolünü sağladım
                {
                    ViewBag.hata = "Girdiğiniz Şifreler Birbiriyle Uyuşmuyor. Lütfen Tekrar Kontrol Ediniz...";
                }
                else
                {
                    wm.TAdd(p.Writers);
                }
                return RedirectToAction("Index", "Recipe");
            }
            else
            {
                p.DistrictID = SelectedDistrictID;

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
            var districts = db.Districts.Where(d => d.CityID == selectedCity).ToList();
            return Json(districts);
        }
    }
}