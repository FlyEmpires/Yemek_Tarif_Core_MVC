using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Yemek_Tarif_Core_MVC.Models;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    [AllowAnonymous]
    [Route("Account")] //Identity ile Authentication cookie kısmı çakıştı bu sebeple Identity kütüphanesinde returnUrl olarak /Account/Login olarak yönlendirdiği için ona göre isim verdim.
    public class LoginController : Controller
    {
        //WriterManager wm = new(new EFWriterRepository());
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
                _signInManager = signInManager;
        }
        [Route("Login")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel user)
        {
            if (ModelState.IsValid)
            {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");

                }
            }
            return View();  
        }

        //      [HttpPost]
        //public async Task<IActionResult> Index(Writer p)
        //{

        //          var value = wm.WriterLogin(p);
        //          if (value is not null)
        //          {
        //              var claims = new List<Claim> // Claim nesneleri, bir kimlik doğrulama işleminde kullanıcının sahip olduğu temel bilgileri(ad, e-posta, rol vb.) temsil eder
        //              {
        //                  new Claim(ClaimTypes.Name,p.WriterMail)
        //              };
        //              var userIdentity = new ClaimsIdentity(claims, "a");
        //              ClaimsPrincipal principal = new(userIdentity);
        //              await HttpContext.SignInAsync(principal);
        //              return RedirectToAction("Index", "Default");
        //          }
        //          else
        //              return View();


        //}
        [Route("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
        [Route("AccesDenied")]
        public IActionResult AccesDenied()
        {
            return View();
        }
    }
}
