using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using EntityLayer.ViewModel;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Yemek_Tarif_Core_MVC.Models;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    [AllowAnonymous]
    public class RecipeController : Controller
    {
        RecipeManager rm = new(new EFRecipeRepository());
        WriterManager wm = new(new EFWriterRepository());
        UserManager um = new(new EFUserRepository());
        UserManager<AppUser> _userManager;
        CategoryManager cm = new(new EFCategoryRepository());
        public IActionResult Index()
        {
            var values = rm.GetListWithCategoryAndWriter();
            return View(values);
        }
        public IActionResult RecipeReadAll(int id)
        {
            ViewBag.commentCount = rm.GetCommentCountByRecipe(id);
            ViewBag.id = id;
            var Minute = rm.Getdate(id);
            var ago = rm.FormatTimeAgo(Minute);
            ViewBag.Minute = ago;
            var values = rm.GetRecipeByID(id);
            var writerID = values.FirstOrDefault().AppUserID;
            ViewBag.WriterName = um.TGetByID(writerID).NameSurname;
            return View(values);
        }
        public IActionResult RecipeListByWriter()
        {
            var writerID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = rm.GetListWithCategoryByWriterRM(int.Parse(writerID));
            return View(values);
        }
        [HttpGet]
        public IActionResult RecipeAdd()
        {
            var values = (from cat in cm.GetList()
                          select new SelectListItem
                          {
                              Text = cat.CategoryName,
                              Value = cat.CategoryID.ToString()
                          }).ToList();
            ViewBag.category = values;
            return View();
        }
        [HttpPost]
        public IActionResult RecipeAdd(Recipe p, IFormFile file)
        {
            RecipeValidator rv = new();
            ValidationResult results = rv.Validate(p);
            var session = User.Identity.Name;
            var writerID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var mail = um.TGetByID(int.Parse(writerID));
            //var writerID = wm.GetSessionByWriter(session).Select(x => x.WriterID).FirstOrDefault();
            var values = (from cat in cm.GetList() /*db.Categories*/
                          select new SelectListItem
                          {
                              Text = cat.CategoryName,
                              Value = cat.CategoryID.ToString()
                          }).ToList();
            ViewBag.cat = values;
            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);
                string imageName = Guid.NewGuid() + imageExtension;
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Tema/images/{imageName}");
                using var stream = new FileStream(imagePath, FileMode.Create);
                file.CopyTo(stream);
                // Eğer mevcut bir dosya varsa, onun yenisiyle yer değiştirmesini sağlıyoruz
                //if (!string.IsNullOrEmpty(p.ReceipeImage))
                //{
                //    string existingImagePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Tema/images/{p.ReceipeImage}");
                //    if (System.IO.File.Exists(existingImagePath))
                //    {
                //        System.IO.File.Delete(existingImagePath);
                //    }
                //}
                p.ReceipeImage = imageName;
                ViewBag.resim = imageName;

            }
            if (results.IsValid)
            {
                p.RecipeStatus = true; //to do: Başlangıçta false olacak, sonradan admin onaylayacak
                p.CreateDate = DateTime.Now;
                p.AppUserID = int.Parse(writerID);
                p.WriterID= 1; // to do: ID Session'dan gelecek
                rm.TAdd(p);
                return RedirectToAction("RecipeListByWriter", "Recipe");
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

        public IActionResult DeleteRecipe(int id)
        {
            var recipeValue = rm.TGetByID(id);
            rm.TDelete(recipeValue);
            return RedirectToAction("RecipeListByWriter");
        }
        [HttpGet]
        public IActionResult EditRecipe(int id)
        {
            var values = (from cat in cm.GetList()
                          select new SelectListItem
                          {
                              Text = cat.CategoryName,
                              Value = cat.CategoryID.ToString()
                          }).ToList();
            ViewBag.cat = values;
            var recipeValue = rm.TGetByID(id);
            return View(recipeValue);
        }

        [HttpPost]
        public IActionResult EditRecipe(Recipe r)
        {
            //var session = User.Identity.Name;
            var writerID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var writerID = wm.GetSessionByWriter(session).Select(x => x.WriterID).FirstOrDefault();
            r.WriterID = 1;
            r.AppUserID= int.Parse(writerID);
            rm.TUpdate(r);
            return RedirectToAction("RecipeListByWriter");
        }
    }
}
