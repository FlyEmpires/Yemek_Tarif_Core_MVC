using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new()
                {
                    Email=user.Mail,
                    ImageUrl=user.ImageUrl,
                    NameSurname=user.NameSurname,
                    UserName=user.UserName
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
            }
            return View(user);
        }
    }
}
