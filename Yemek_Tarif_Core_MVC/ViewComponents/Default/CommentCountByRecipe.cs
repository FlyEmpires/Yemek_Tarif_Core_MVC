using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.ViewComponents.Default
{
    public class CommentCountByRecipe:ViewComponent
    {
        RecipeManager rm = new(new EFRecipeRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = rm.GetCommentCountByRecipe(id);
            ViewBag.count = values;
            return View(values);
        }
    }
}
