using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Yemek_Tarif_Core_MVC.Models;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class RecipeController : Controller
    {
        public Recipe recipe = null;
        RecipeManager rm = new RecipeManager(new EFRecipeRepository());
        public IActionResult Index()
        {
            var values=rm.GetRecipeListWithCategory();
            return View(values);
        }

        public IActionResult RecipeReadAll(int id)
        {
            //rm.GetByID(id);
            //recipe = rm.GetByID(id);
            //var values = rm.GetByID(id);
            ViewBag.id = id;
            var values=rm.GetRecipeByID(id);
            return View(values);
        }
    }
}
