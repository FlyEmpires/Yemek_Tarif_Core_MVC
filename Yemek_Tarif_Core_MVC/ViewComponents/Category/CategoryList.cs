using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace Yemek_Tarif_Core_MVC.ViewComponents.Category
{
    //public class CategoryList:ViewComponent
    //{
    //    CategoryManager cm = new(new EFCategoryRepository());

    //        DataAccessLayer.Concrete.Context db = new();
    //    public IViewComponentResult Invoke()
    //    {
    //        var category = (from cat in db.Categories.ToList()
    //                        join recipe in db.Recipes on cat.CategoryID equals recipe.CategoryID
    //                        select cat).ToList();



    //        var values = cm.GetList();
    //        return View(values);
    //    }


    //}

    public class CategoryList : ViewComponent
    {
        CategoryManager cm = new(new EFCategoryRepository());


        public IViewComponentResult Invoke()
        {
            Context db = new();
            Models.CategoryListWithCount count = new();
            //var categoryCount = (from cat in db.Categories
            //                select new Models.CategoryListWithCount
            //                {
            //                    CategoryName=cat.CategoryName,
            //                    CategoryID=cat.CategoryID,
            //                    RecipeCount=cat.Recipes.Count(),
            //                    CategoryDescription=cat.CategoryDescription
            //                }).ToList();

            var values = CategoryManager.GetListWithCount();


            return View(values);
        }
    }
}
