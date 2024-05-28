using BusinessLayer.Concrete;
using BusinessLayer.Statistic;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {
        AdminManager adm = new(new EFAdminRepository());
        public IViewComponentResult Invoke()
        {
            ViewBag.adminName=adm.TGetByID(1).Name;
            ViewBag.adminImageURL=adm.TGetByID(1).ImageURL;
            ViewBag.adminDescription=adm.TGetByID(1).ShortDescription;
            ViewBag.totalLike = Statistics.TotalLike();
            return View();
        }
    }
}
