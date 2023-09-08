using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        CommentManager cm = new(new EFCommentRepository());
        public IActionResult Index()
        {
            var values = cm.GetCommentWithRecipe();
            return View(values);
        }
    }
}
