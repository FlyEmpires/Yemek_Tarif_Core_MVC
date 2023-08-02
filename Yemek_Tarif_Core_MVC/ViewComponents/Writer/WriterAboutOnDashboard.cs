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
            var values = wm.GetWriterByID(1).FirstOrDefault();
            return View(values);
        }
    }
}
