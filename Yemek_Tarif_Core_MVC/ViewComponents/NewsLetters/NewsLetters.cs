using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.ViewComponents.NewsLetters
{
    public class NewsLetters:ViewComponent
    {
        RecipeManager rm = new(new EFRecipeRepository());
        NewsLetterManager nm = new(new EFNewsLetterRepository());

        public IViewComponentResult Invoke(NewsLetter p,int id)
        {
            
            ViewBag.id = id;
            //ViewBag.sonuc = 1;
            return View(id);
        }
     
    }
}
