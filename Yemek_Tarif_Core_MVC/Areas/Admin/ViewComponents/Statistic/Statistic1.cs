using BusinessLayer.Concrete;
using BusinessLayer.Statistic;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Yemek_Tarif_Core_MVC.Controllers;

namespace Yemek_Tarif_Core_MVC.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        WriterManager wm = new(new EFWriterRepository());
        public async Task<IViewComponentResult> InvokeAsync()
        {
           ViewBag.forecast= await DefaultController.Derece();
            ViewBag.totalCount = Statistics.RecipeCount();
            ViewBag.commentCount = Statistics.CommentCount();
            //ViewBag.totalCount = wm.TotalRecipeCount();
            //ViewBag.totalMessageCount = wm.TotalMessageCount();
            ViewBag.totalMessageCount = Statistics.MessageCount();
            return  View();
        }
    }
}
