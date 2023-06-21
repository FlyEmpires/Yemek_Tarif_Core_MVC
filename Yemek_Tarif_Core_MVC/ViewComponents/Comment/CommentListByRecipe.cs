using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace Yemek_Tarif_Core_MVC.ViewComponents.Comment
{
	public class CommentListByRecipe:ViewComponent
	{
		CommentManager cm = new(new EFCommentRepository());
		Context db = new();
		public IViewComponentResult Invoke(int id)
		{


			//ViewBag.cathListCount= (from cat in db.Categories.ToList()
			//		   join recipe in db.Recipes on cat.CategoryID equals recipe.CategoryID select cat).ToList();

			//var count= cathListCount.Count();
            var values = cm.GetList(id);
			return View(values);
		}
	}
}