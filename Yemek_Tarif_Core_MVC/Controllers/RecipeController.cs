using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Yemek_Tarif_Core_MVC.Models;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class RecipeController : Controller
    {
        RecipeManager rm = new(new EFRecipeRepository());
        public IActionResult Index()
        {
            Context db = new();
            var commentCount = (from comment in db.Comments join recipe in db.Recipes on comment.ReceipeID equals recipe.ReceipeID select new CommentCountByRecipe
            {
                RecipeID = recipe.ReceipeID,
                CommentCount = recipe.Comments.Count(),
                //Category=recipe.Category,
                CreateDate=recipe.CreateDate,
                RecipeName=recipe.ReceipeName
            }).ToList();

            var commentCountt = (from recipe in db.Recipes
                                join comment in db.Comments on recipe.ReceipeID equals comment.ReceipeID
                                select new CommentCountByRecipe
                                {
                                    RecipeID = recipe.ReceipeID,
                                    CommentCount = recipe.Comments.Count(),
                                    Category = recipe.Category,
                                    CreateDate = recipe.CreateDate,
                                    RecipeName = recipe.ReceipeName
                                }).Distinct().ToList();
            ViewBag.yorum = commentCount;
            var values=rm.GetRecipeListWithCategory();
            return View(values);
        }

        public IActionResult RecipeReadAll(int id)
        {
            Context db = new();
            ViewBag.commentCount = (from cmnt in db.Comments where id==cmnt.ReceipeID select cmnt).ToList().Count();
            //rm.GetByID(id);
            //recipe = rm.GetByID(id);
            //var values = rm.GetByID(id);
            ViewBag.id = id;
            var values=rm.GetRecipeByID(id);
            return View(values);
        }
    }
}
