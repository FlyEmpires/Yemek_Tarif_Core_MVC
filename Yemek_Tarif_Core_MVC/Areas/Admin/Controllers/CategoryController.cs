using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using X.PagedList;

namespace Yemek_Tarif_Core_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new(new EFCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var values = cm.GetList().ToPagedList(page,3);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator cv = new();
            ValidationResult result = cv.Validate(p);
            if (result.IsValid)
            {
                p.CategoryStatuss = true;
                cm.TAdd(p);
                return RedirectToAction("Index", "Category");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult CategoryDelete(int id)
        {
            var values = cm.TGetByID(id);
            values.CategoryStatuss = false;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var catid=cm.TGetByID(id);
            return View(catid);
        }

        //[HttpPost]
        //public IActionResult EditCategory(Category p)
        //{
        //    CategoryValidator cv = new();
        //    p.CategoryDescription = "test";
        //    ValidationResult result = cv.Validate(p);
        //    if (result.IsValid)
        //    {
        //        cm.TUpdate(p);
        //        return RedirectToAction("Index", "Category");

        //    }
        //    else
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();

        //}

        //[HttpPost]
        //public IActionResult EditCategory(Category p)
        //{
        //    using (Context db = new Context())
        //    {
        //        var id = (from i in db.Categories where i.CategoryID == p.CategoryID select i).FirstOrDefault();

        //        id.CategoryName = p.CategoryName;
        //        id.CategoryDescription = "test123";

        //        try
        //        {
        //            db.Entry(id).State = EntityState.Modified;

        //            db.SaveChanges();
        //            return RedirectToAction("Index", "Category");
        //        }
        //        catch (Exception ex)
        //        {
        //            // Hata işleme
        //            return View("Error");
        //        }
        //    }
        //}
        [HttpPost]
        public IActionResult EditCategory(Category p)
        {
            using (Context db=new Context())
            {
                var id = (from i in db.Categories where i.CategoryID == p.CategoryID select i).FirstOrDefault();

                id.CategoryName = p.CategoryName;
                id.CategoryDescription = "test123";
                db.Entry(id).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            
        }
    }
}
