using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Xml.Linq;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager cm = new(new EFCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialAddComment(int RecipeID)
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(/*Comment p,*//*int RecipeID,*/ /*string txtName,string txtEmail,string txtKonu,string txtMesaj*/ [FromBody] Comment p,int like )
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            p.RecipeScore = like;
            //p.ReceipeID=
            //int like = Convert.ToInt32(Request.Form["like"]);
            //cm.CommentAdd(p);
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            var values=cm.GetList(id);
            return PartialView(values);
        }
        public IActionResult Deneme()
        {
            return View();
        }
    }
}
