using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using EntityLayer.ViewModel;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yemek_Tarif_Core_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        //WriterManager wm = new(new EFWriterRepository());
        UserManager um = new(new EFUserRepository());
        public IActionResult Index()
        {
            Context db = new();
            var cityValues = (from city in db.Cities
                          select new SelectListItem
                          {
                              Text = city.CityName,
                              Value = city.CityID.ToString()
                          }).ToList();

            var districtValues = (from district in db.Districts
                          select new SelectListItem
                          {
                              Text = district.DistrictName,
                              Value = district.DistrictID.ToString()
                          }).ToList();
            ViewBag.city = cityValues;
            ViewBag.district= districtValues;
            return View();
        }
        public IActionResult WriterList()
        {
            var list = um.GetList();
            return Json(list);
        }
        [HttpGet]
        public IActionResult GetWriterByID(int writerID)
        {
            var getWriter = um.TGetByID(writerID);
            var jsonWriter=JsonConvert.SerializeObject(getWriter);
            return Json(jsonWriter);
        }
        [HttpPost]
        public IActionResult WriterAdd(WriterCityViewModel writer/*,string geciciSifre*/)
        {
            Context db = new();
            var cityList = (from i in db.Cities.ToList() select i).ToList();
            writer.City = cityList;
            //writer.District = districtList;
            //WriterValidator wv = new(geciciSifre);
            WriterValidator wv = new ();
            ValidationResult results = wv.Validate(writer);
            if (results.IsValid)
            {
                //writer.Writers.WriterStatus = true;
                //writer.Writers.WriterAbout = "Deneme";
                //writer.Writers.CityID = writer.SelectedCityID;
               
              
                    //wm.TAdd(writer.Writers);
                um.TAdd(writer.Writers);

                return Json(new { isSuccess = true }); // Başarılı olduğunu döndür
                //return RedirectToAction("Index", "/Admin/Writer/");
            }
            else
            {

                var errorMessages = results.Errors.ToDictionary(e => e.PropertyName, e => e.ErrorMessage);
                return Json(new { isSuccess = false, errorMessage = errorMessages });

                //foreach (var error in errorMessages)
                //{
                //    ModelState.AddModelError(error.Key, error.Value);
                //}


            }
            //return View("Index",writer);
        }
        public IActionResult WriterDelete(int id)
        {
            Context db = new();
            var writer = um.TGetByID(id);
            um.TDelete(writer);
            return Json(writer);
        }

        public IActionResult GetWriterUpdate(int id)
        {
            var value = um.TGetByID(id);
            return Json(value);
        }
        [HttpPost]
        public IActionResult GetUpdate(WriterCityViewModel w)
        {          
            um.TUpdate(w.Writers);
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }
      
    }
}
