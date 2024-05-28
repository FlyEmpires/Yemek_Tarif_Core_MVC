using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class DashboardController : Controller
    {
        WriterManager wm = new(new EFWriterRepository());
        UserManager um = new(new EFUserRepository());
        public IActionResult Index()
        {
            //Burada 4 satırda bulduğumuz WriterID'yi aşağıda FindFirstValue metodu ile 1 satırda buldum
            //Context db= new Context();  
            //var session = User.Identity.Name;
            //var userMail = db.Users.Where(x => x.UserName == session).Select(x => x.Email).FirstOrDefault();
            //var userID=db.Users.Where(x => x.Email== userMail).Select(x => x.Id).FirstOrDefault();

            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.totalCount = wm.TotalRecipeCount();
            ViewBag.totalCountByWriter = um.TotalRecipeCountByWriter(int.Parse(userID));
            ViewBag.TotalRecipeCountLast7Days = wm.TotalRecipeCountLast7Days();
            return View();
        }
    }
}
