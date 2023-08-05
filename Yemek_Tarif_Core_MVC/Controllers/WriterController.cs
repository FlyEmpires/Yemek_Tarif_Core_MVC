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

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new(new EFWriterRepository());
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
        public IActionResult WriterEditProfile()
        {
            var session = User.Identity.Name;
            var writerID = wm.GetSessionByWriter(session).Select(x => x.WriterID).FirstOrDefault();
            var writerValues = wm.TGetByID(writerID);
            return View(writerValues);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer w,string geciciSifre,IFormFile file)
        {
            AnotherModelValidator wv = new(geciciSifre);
            ValidationResult results = wv.Validate(w);
            if (results.IsValid)
            {
                if (file != null)
                {
                    string imageExtension = Path.GetExtension(file.FileName);
                    string imageName = Guid.NewGuid() + imageExtension;
                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Tema/images/{imageName}");
                    using var stream = new FileStream(imagePath, FileMode.Create);
                    file.CopyTo(stream);
                    // Eğer mevcut bir dosya varsa, onun yenisiyle yer değiştirmesini sağlıyoruz
                    if (!string.IsNullOrEmpty(w.WriterImage))
                    {
                        string existingImagePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Tema/images/{w.WriterImage}");
                        if (System.IO.File.Exists(existingImagePath))
                        {
                            System.IO.File.Delete(existingImagePath);
                        }
                    }
                    w.WriterImage = imageName;
                }
                wm.TUpdate(w);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(w);
        }
    }
}
