using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRecipeController : Controller
    {
        RecipeManager rm = new(new EFRecipeRepository());
        public IActionResult Index()
        {
            var values=rm.GetListWithCategoryAndWriter();
            return View(values);
        }
    }
}
