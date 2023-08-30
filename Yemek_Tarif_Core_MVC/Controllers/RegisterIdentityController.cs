using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using EntityLayer.Concrete;
using EntityLayer.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Yemek_Tarif_Core_MVC.Models;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    [AllowAnonymous]
    public class RegisterIdentityController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterIdentityController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            Context db = new();

            var value = db.Cities.Include(d => d.District).ToList();
            UserRegisterViewModel cd = new()
            {
                City = value,
                SelectedCityID = value.FirstOrDefault().CityID,
                District = value.FirstOrDefault().District,
                DistrictID = value.FirstOrDefault().District.FirstOrDefault().DistrictID
            };
            return View(cd);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel user, int SelectedDistrictID)
        {
            Context db = new();

            var cityList = (from i in db.Cities.ToList() select i).ToList();
            var districtList = (from d in db.Districts where SelectedDistrictID == d.DistrictID select d).ToList();
            user.City = cityList;
            user.District = districtList;
            //if (ModelState.IsValid)
            //{
                AppUser appUser = new()
                {
                    Email=user.Mail,
                    ImageUrl=user.ImageUrl,
                    NameSurname=user.NameSurname,
                    UserName=user.UserName,
                    CityID=user.SelectedCityID,
                    DistrictID=SelectedDistrictID
                };
                var result = await _userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            //}
            return View(user);
        }
    }
}
