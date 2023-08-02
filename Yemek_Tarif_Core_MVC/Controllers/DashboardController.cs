using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class DashboardController : Controller
    {
        WriterManager wm = new(new EFWriterRepository());
        public IActionResult Index()
        {
            ViewBag.totalCount = wm.TotalRecipeCount();
            ViewBag.totalCountByWriter = wm.TotalRecipeCountByWriter(1);
            ViewBag.TotalRecipeCountLast7Days = wm.TotalRecipeCountLast7Days();
            return View();
        }
    }
}
