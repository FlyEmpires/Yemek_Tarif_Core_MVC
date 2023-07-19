using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Yemek_Tarif_Core_MVC.Models;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    [AllowAnonymous]
    public class RecipeController : Controller
    {
        RecipeManager rm = new(new EFRecipeRepository());
        public IActionResult Index()
        {
            var values=rm.GetListWithCategoryAndWriter();
            return View(values);
        }
        public IActionResult RecipeReadAll(int id)
        {
            ViewBag.commentCount= rm.GetCommentCountByRecipe(id);
            ViewBag.id = id;
            var Minute = rm.Getdate(id);
            ViewBag.Minute = Minute;
            var values=rm.GetRecipeByID(id);
            return View(values);
        }
    }
}
