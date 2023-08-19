using BusinessLayer.Statistic;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Yemek_Tarif_Core_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        { 
            return View();
        }

        [HttpGet]
        public JsonResult PieChart()
        {
           var pieChartList= Statistics.PieChart();
            return Json(pieChartList);
        }
    }
}
