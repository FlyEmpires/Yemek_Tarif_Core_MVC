using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Yemek_Tarif_Core_MVC.ViewComponents.Recipe
{
    public class WriterLastRecipes:ViewComponent
    {
        RecipeManager rm = new(new EFRecipeRepository());
        UserManager um = new(new EFUserRepository());
        public IViewComponentResult Invoke(int id)
        {
            var recipe= rm.GetRecipeByID(id).FirstOrDefault();
            var lastRecipeWriter = recipe.AppUserID;
            //var session = User.Identity.Name;

            //var writerID = um.GetSessionByWriter(session).Id;

            var values = rm.GetRecipeListWithWriter(lastRecipeWriter);
            return View(values);
        }
    }
}
