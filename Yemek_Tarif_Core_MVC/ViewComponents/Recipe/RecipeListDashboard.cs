using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.ViewComponents.Recipe
{
    public class RecipeListDashboard:ViewComponent
    {
        RecipeManager rm = new(new EFRecipeRepository());
        public IViewComponentResult Invoke()
        {
            var values = rm.GetListWithCategoryAndWriter();
            return View(values);  
        }
    }
}
