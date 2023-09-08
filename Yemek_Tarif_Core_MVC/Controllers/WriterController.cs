using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.ViewModel;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using Yemek_Tarif_Core_MVC.Models;
using System.Security.Claims;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new(new EFWriterRepository());
        UserManager<AppUser> _userManager;
        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

       

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        public IActionResult Writer()
        {
            return View();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            UserUpdateViewModel model = new();   
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            model.UserName = values.UserName;
            model.ImageUrl = values.ImageUrl;
            model.NameSurname = values.NameSurname;
            model.Mail = values.Email;

            //UserManager um = new(new EFUserRepository());

            //var userName = User.Identity.Name;
            //var userMail = wm.GetWriterMail(userName);
            //var writerID = wm.GetSessionByWriter(userMail).Select(x => x.WriterID).FirstOrDefault();
            //var writerValues = wm.TGetByID(writerID);
            //return View(writerValues);
            //var userID = values.Result.Id.ToString();
            //var userValues= um.TGetByID(int.Parse(userID));
            return View(model);
        }
        [HttpPost]
        public async  Task<IActionResult> WriterEditProfile(UserUpdateViewModel user,string checkbox,string geciciSifre,IFormFile file)
        { 
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = user.NameSurname;
            values.PhoneNumber = user.PhoneNumber;
            if (checkbox!=null)
            {
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, user.Password);
            }
            //UserManager um=new(new EFUserRepository());
            //AnotherModelValidator wv = new(geciciSifre);
            //ValidationResult results = wv.Validate(user);
            //if (results.IsValid)
            //{
            if (file != null)
                {
                    string imageExtension = Path.GetExtension(file.FileName);
                    string imageName = Guid.NewGuid() + imageExtension;
                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Tema/images/{imageName}");
                    using var stream = new FileStream(imagePath, FileMode.Create);
                    file.CopyTo(stream);
                    // Eğer mevcut bir dosya varsa, onun yenisiyle yer değiştirmesini sağlıyoruz
                    if (!string.IsNullOrEmpty(user.ImageUrl))
                    {
                        string existingImagePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Tema/images/{user.ImageUrl}");
                        if (System.IO.File.Exists(existingImagePath))
                        {
                            System.IO.File.Delete(existingImagePath);
                        }
                    }
                    //user.ImageUrl = imageName;
                    values.ImageUrl = imageName;

            }
            var result = await _userManager.UpdateAsync(values);
                //um.TUpdate(user);
                return RedirectToAction("Index", "Dashboard");
            //}
            //else
            //{
            //    //foreach (var item in results.Errors)
            //    //{
            //    //    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    //}
            //}
            //return View(user);
        }

       
    }
}
