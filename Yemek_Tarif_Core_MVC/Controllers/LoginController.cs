using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterManager wm = new(new EFWriterRepository());
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> Index(Writer p)
		{

            var value = wm.WriterLogin(p);
            if (value is not null)
            {
                var claims = new List<Claim> // Claim nesneleri, bir kimlik doğrulama işleminde kullanıcının sahip olduğu temel bilgileri(ad, e-posta, rol vb.) temsil eder
                {
                    new Claim(ClaimTypes.Name,p.WriterMail)
                };
                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Default");
            }
            else
                return View();
            //var value=wm.WriterLogin(p);
            //if (value!=null)
            //{
            //    HttpContext.Session.SetString("username", p.WriterMail);
            //    return RedirectToAction("Index", "Writer");
            //}
            //else
            //{
            //    return View();
            //}
			
		}
	}
}
