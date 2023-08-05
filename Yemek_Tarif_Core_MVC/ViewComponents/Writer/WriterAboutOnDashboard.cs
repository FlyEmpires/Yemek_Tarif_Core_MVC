using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Yemek_Tarif_Core_MVC.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager wm = new(new EFWriterRepository());
        public IViewComponentResult Invoke()
        {
            var session = User.Identity.Name;
            var writerID = wm.GetSessionByWriter(session).Select(x=>x.WriterID).FirstOrDefault();
            var values = wm.GetWriterByID(writerID).FirstOrDefault();
            return View(values);
        }
    }
}
