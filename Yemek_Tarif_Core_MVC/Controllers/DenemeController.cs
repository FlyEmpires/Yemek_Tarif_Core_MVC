using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Yemek_Tarif_Core_MVC.Models;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class DenemeController : Controller
    {
        Context db = new();

        public IActionResult Index()
        {
            var values = (from city in db.Cities.ToList() join district in db.Districts on city.Id equals district.Id select city).Distinct().ToList();
            CityAndDistrict cd = new()
            {
                City = values,
                SelectedCityID = values.FirstOrDefault().Id,
                District=values.FirstOrDefault().Districts,
                DistrictID=values.FirstOrDefault().Districts.FirstOrDefault().DistrictID
            };
            return View(cd);
        }

        //[HttpPost]
        //public IActionResult Index(int selectedCity)
        //{
        //    var districts = db.Districts.Where(d => d.Id == selectedCity).ToList();
        //    return Json(new { districts });

        //}
        [HttpPost]
        public IActionResult Index(int selectedCity)
        {
            var districts = db.Districts.Where(d => d.Id == selectedCity).ToList();
            return Json(districts);
        }

    }
}
