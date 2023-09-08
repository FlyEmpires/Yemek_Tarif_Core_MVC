using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.ViewComponents.Writer
{
    public class WriterNameSurname:ViewComponent
    {
        UserManager um = new(new EFUserRepository());

        public IViewComponentResult Invoke()
        {
            string userName = User.Identity.Name;
            var values = um.GetSessionByWriter(userName);
            var name = values.NameSurname;
            ViewData["NameSurname"] = name;

            //ViewBag.NameSurname = name;
            return View();
        }
    }
}
