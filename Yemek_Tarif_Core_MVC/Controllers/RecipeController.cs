using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class RecipeController : Controller
    {
        RecipeManager rm = new RecipeManager(new EFRecipeRepository());
        public IActionResult Index()
        {
            var values=rm.GetRecipeListWithCategory();
            return View(values);
        }

        public IActionResult YemekDetay(int id)
        {
            //rm.GetByID(id);
            var values = rm.GetByID(id);
            return View(values);
        }
    }
}
