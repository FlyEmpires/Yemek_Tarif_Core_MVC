using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Yemek_Tarif_Core_MVC.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        //WriterManager wm = new(new EFWriterRepository());
        UserManager um = new(new EFUserRepository());
        private  readonly UserManager<AppUser> _userManager;

        public WriterAboutOnDashboard(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            //Context db = new();
            //var user =  await _userManager.FindByNameAsync(User.Identity.Name);
            //var session = User.Identity.Name;
            //var userMail = db.Users.Where(x => x.UserName == session).Select(x => x.Email).FirstOrDefault();
            //ViewBag.User = session;    
            //var writerID = wm.GetSessionByWriter(userMail).Select(x=>x.WriterID).FirstOrDefault();
            //var values = wm.GetWriterByID(writerID).FirstOrDefault();
            //var writerID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userName = User.Identity.Name;
            var values = um.GetSessionByWriter(userName);
            return View(values);
        }
    }
}
