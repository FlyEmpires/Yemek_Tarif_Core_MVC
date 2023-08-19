using BusinessLayer.Statistic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Yemek_Tarif_Core_MVC.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.lastRecipe = Statistics.LastRecipe().ReceipeName;
            ViewBag.lastRecipeID = Statistics.LastRecipe().ReceipeID;
            return View();
        }
    }
}
