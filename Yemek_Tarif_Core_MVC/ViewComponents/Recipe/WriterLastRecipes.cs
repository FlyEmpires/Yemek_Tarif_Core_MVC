using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.ViewComponents.Recipe
{
    public class WriterLastRecipes:ViewComponent
    {
        RecipeManager rm = new(new EFRecipeRepository());

        public IViewComponentResult Invoke()
        {
            var values = rm.GetRecipeListWithWriter(1);
            return View(values);
        }
    }
}
