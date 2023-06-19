using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        public PartialViewResult CommentListByBlog()
        {
            
            return PartialView();
        }
    }
}
