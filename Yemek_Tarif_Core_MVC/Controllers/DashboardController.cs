using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class DashboardController : Controller
    {
        WriterManager wm = new(new EFWriterRepository());
        public IActionResult Index()
        {
            Context db= new Context();  
            var session = User.Identity.Name;
            var userMail = db.Users.Where(x => x.UserName == session).Select(x => x.Email).FirstOrDefault();
            var userID=db.Users.Where(x => x.Email== userMail).Select(x => x.Id).FirstOrDefault();
            ViewBag.totalCount = wm.TotalRecipeCount();
            ViewBag.totalCountByWriter = wm.TotalRecipeCountByWriter(userID);
            ViewBag.TotalRecipeCountLast7Days = wm.TotalRecipeCountLast7Days();
            return View();
        }
    }
}
