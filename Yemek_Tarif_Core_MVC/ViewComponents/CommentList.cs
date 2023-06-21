using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Yemek_Tarif_Core_MVC.ViewComponents
{
    public class CommentList:ViewComponent
    {
        CommentManager cm = new CommentManager(new EFCommentRepository());
       
        public IViewComponentResult Invoke(int id)
        {
            var values =cm.GetList(id);
            return View(values);
        }
    }
}
