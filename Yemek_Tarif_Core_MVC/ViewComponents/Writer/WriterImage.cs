using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.ViewComponents.Writer
{
    public class WriterImage:ViewComponent
    {
        UserManager um = new(new EFUserRepository());
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var userImage = um.GetSessionByWriter(userName).ImageUrl;
            ViewBag.UserImage= userImage;
            return View();
        }
    }
}
